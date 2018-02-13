using Pasarela.Core.Extensions;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Services.ShelterHouse;
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
    public class MyShelterHouseViewModel : ViewModelBase
    {

        private ObservableCollection<ShelterHouse> _shelterHouse;
        private IShelterHouseService _shelterHouseService;

        public MyShelterHouseViewModel(IShelterHouseService shelterHouseService)
        {
            _shelterHouseService = shelterHouseService;
        }

        public ObservableCollection<ShelterHouse> ListShelterHouse
        {
            get { return _shelterHouse; }
            set
            {
                _shelterHouse = value;
                RaisePropertyChanged(() => ListShelterHouse);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var shelterHouseList = await _shelterHouseService.GetShelterHouseByUserAsync(2);
            foreach (var item in shelterHouseList)
            {
                if (item.Photos.Count == 0)
                {
                    item.Photos.Add(new Models.PhotoShelterHouse.PhotoShelterHouse() { Photo = "ic_default" });
                }
            }
            ListShelterHouse = shelterHouseList.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand ViewDetailCommand => new Command(async (item) => await ViewDetailAsync(item));

        private async Task ViewDetailAsync(object item)
        {
            IsBusy = true;
            var shelterHouse = item as ShelterHouse;
            await NavigationService.NavigateToAsync<ShelterHouseDetailViewModel>(shelterHouse);
            IsBusy = false;
        }

        public ICommand DonateCommand => new Command(async (item) => await DonateAsync(item));

        private async Task DonateAsync(object item)
        {
            IsBusy = true;
            var shelterHouse = item as ShelterHouse;
            await NavigationService.NavigateToAsync<DonateViewModel>(shelterHouse);
            IsBusy = false;
        }

    }
}
