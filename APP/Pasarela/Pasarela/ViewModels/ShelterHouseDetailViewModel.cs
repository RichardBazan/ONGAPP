using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class ShelterHouseDetailViewModel : ViewModelBase
    {
        private ShelterHouse _shelterHouse;

        public ShelterHouseDetailViewModel()
        {

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

        public override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as ShelterHouse;
            ShelterHouse = data;
            
            return base.InitializeAsync(navigationData);
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

        public ICommand DonateCommand => new Command(async () => await DonateAsync());

        private async Task DonateAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<DonateViewModel>(ShelterHouse);
            IsBusy = false;
        }

    }
}
