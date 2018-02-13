using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Dog;
using Pasarela.Core.Services.Dog;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class AdoptUserViewModel: ViewModelBase
    {

        private ObservableCollection<Dog> _dog;
        private IDogService _dogService;

        public AdoptUserViewModel(IDogService dogService)
        {
            _dogService = dogService;
        }

        public ObservableCollection<Dog> ListDog
        {
            get { return _dog; }
            set
            {
                _dog = value;
                RaisePropertyChanged(() => ListDog);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var dogList = await _dogService.GetDogUserAsync();
            foreach (var item in dogList)
            {
                if (item.Photos.Count == 0)
                {
                    item.Photos.Add(new Models.PhotoDog.PhotoDog() { Photo = "ic_default" });
                }
            }
            ListDog = dogList.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand ViewDetailCommand => new Command(async (item) => await ViewDetailAsync(item));

        private async Task ViewDetailAsync(object item)
        {
            IsBusy = true;
            var dog = item as Dog;
            await NavigationService.NavigateToAsync<AdoptionDetailViewModel>(dog);
            IsBusy = false;
        }

        public ICommand AdoptCommand => new Command(async (item) => await AdoptAsync(item));

        private async Task AdoptAsync(object item)
        {
            IsBusy = true;
            var dog = item as Dog;
            await NavigationService.NavigateToAsync<ConfirmationAdoptionViewModel>(dog);
            IsBusy = false;
        }

    }
}
