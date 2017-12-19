using Pasarela.Core.Extensions;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Banner;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.Home;
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
    public class HomeViewModel: ViewModelBase
    {
        private ObservableCollection<Banner> _banner;
        private IHomeService _homeService;

        public HomeViewModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ObservableCollection<Banner> Banner
        {
            get { return _banner; }
            set
            {
                _banner = value;
                RaisePropertyChanged(() => Banner);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var banner = await _homeService.GetBannerAsync();
            Banner = banner.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand AdoptionCommand => new Command(async () => await AdoptionNavigate());

        private async Task AdoptionNavigate()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainAdoptionViewModel>();
            IsBusy = false;
        }

        public ICommand ComplaintCommand => new Command(async () => await ComplaintNavigate());

        private async Task ComplaintNavigate()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainAbuseViewModel>();
            IsBusy = false;
        }

        public ICommand ShelterHouseCommand => new Command(async () => await ShelterHouseNavigate());

        private async Task ShelterHouseNavigate()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainShelterHouseViewModel>();
            IsBusy = false;
        }

        public ICommand GiveInAdoptionCommand => new Command(async () => await GiveInAdoptionNavigate());

        private async Task GiveInAdoptionNavigate()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<GiveInAdoptionViewModel>();
            IsBusy = false;
        }
        

    }
}
