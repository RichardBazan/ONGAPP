using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.Donate;
using Pasarela.Core.Models.DonateProduct;
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
        private Product _product;
        private string _selectedCount;
        private string product;
        private string quantity;
        private ObservableCollection<DonateProduct> _donateproduct;

        public DonateViewModel( IDonateService donateService, IProductService productService)
        {
            VisibleComment = false;
            _donateService = donateService;
            _productService = productService;
            ListProductDonate = new ObservableCollection<DonateProduct>();
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

        public ObservableCollection<DonateProduct> ListProductDonate
        {
            get { return _donateproduct; }
            set
            {
                _donateproduct = value;
                RaisePropertyChanged(() => ListProductDonate);
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

        public Product SelectedProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged(() => SelectedProduct);
            }
        }

        public string SelectedCount
        {
            get { return _selectedCount; }
            set
            {
                _selectedCount = value;
                RaisePropertyChanged(() => SelectedCount);
            }
        }

        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                RaisePropertyChanged(() => Quantity);
            }
        }

        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                RaisePropertyChanged(() => Product);
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

        public ICommand AddCommand => new Command(async () => await AddAsync());

        private async Task AddAsync()
        {
            ListProductDonate.Add(new DonateProduct() { ProductId = SelectedProduct.Id, Name = SelectedProduct.Name, Quantity = SelectedCount });
            ListProductDonate = ListProductDonate.ToObservableCollection();
        }

        public ICommand GiveDonateCommand => new Command(async () => await GiveDonateAsync());

        private async Task GiveDonateAsync()
        {
            try
            {
                var saveDonate = new SaveDonate()
                {
                    IdShelterHouse = ShelterHouse.Id,
                    IdUser = GlobalSetting.UserInfo.Id
                    //ListProducts= ListProductDonate.ToList()
                };
                await _donateService.SaveDonateAsync(saveDonate);

                var saveDonateProduct = new ProductDonate()
                {
                    ListProducts = ListProductDonate.ToList()
                };
                await _donateService.SaveProductDonateAsync(saveDonateProduct);

                await DialogService.ShowAlertAsync("Se registro con éxito su donación", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
            }

            
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

        public ICommand CancelDonateCommand => new Command(async () => await CancelDonateAsync());

        private async Task CancelDonateAsync()
        {
            VisibleComment = false;
        }

        public ICommand DeleteCommand => new Command(async () => await DeleteAsync());

        private async Task DeleteAsync()
        {
            //ListProductDonate.Remove()
        }
    }
}
