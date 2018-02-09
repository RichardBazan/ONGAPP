using Pasarela.Core.Extensions;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Banner;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.Home;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Banner> _banner;
        private IHomeService _homeService;
        private ImageSource _photoUser;
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

        public ImageSource PhotoUser
        {
            get { return _photoUser; }
            set
            {
                _photoUser = value;
                RaisePropertyChanged(() => PhotoUser);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            //var banner = await _homeService.GetBannerAsync();
            //Banner = banner.ToObservableCollection();
            string p = GlobalSetting.UserInfo.Photo;
            p = p.Substring(23);
            var bytes = Convert.FromBase64String(p);
            Stream contents = new MemoryStream(bytes);
            PhotoUser = ImageSource.FromStream(() => { return contents; });
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

        public ICommand ConfigurationCommand => new Command(async () => await ConfigurationAsync());

        private async Task ConfigurationAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<MainConfigurationViewModel>();
            IsBusy = false;
        }


    }
}
