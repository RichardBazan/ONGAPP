using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Donate;
using Pasarela.Core.Models.Product;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Services.Donate;
using Pasarela.Core.Services.Product;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class DonateViewModel : ViewModelBase
    {
        private ShelterHouse _shelterHouse;
        private bool _visibleComment;
        private ObservableCollection<Donate> _donate;
        private ObservableCollection<Product> _products;
        private IDonateService _donateService;
        private IProductService _productService;

        public DonateViewModel( IDonateService donateService, IProductService productService)
        {
            VisibleComment = false;
            _donateService = donateService;
            _productService = productService;
        }

        public bool VisibleComment
        {
            get { return _visibleComment; }
            set
            {
                _visibleComment = value;
                RaisePropertyChanged(() => VisibleComment);
            }
        }

        public ShelterHouse ShelterHouse
        {
            get { return _shelterHouse; }
            set
            {
                _shelterHouse = value;
                RaisePropertyChanged(() => ShelterHouse);
            }
        }

        public ObservableCollection<Donate> ListDonate
        {
            get { return _donate; }
            set
            {
                _donate = value;
                RaisePropertyChanged(() => ListDonate);
            }
        }

        public ObservableCollection<Product> ListProduct
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged(() => ListProduct);
            }
        }


        public async override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var data = navigationData as ShelterHouse;
            ShelterHouse = data;
            var donate = await _donateService.GetDonateByShelterHouseAsync(ShelterHouse.Id);
            ListDonate = donate.ToObservableCollection();
            var product = await _productService.GetAllProductsAsync();
            ListProduct = product.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand DonateCommand => new Command(async () => await DonateAsync());

        private async Task DonateAsync()
        {
            VisibleComment = true;
        }

        public ICommand CancelDonateCommand => new Command(async () => await CancelDonateAsync());

        private async Task CancelDonateAsync()
        {
            VisibleComment = false;
        }

        //public ICommand AddCommand => new Command(async () => await AddAsync());

        //private async Task AddAsync()
        //{
            
        //}
    }
}
