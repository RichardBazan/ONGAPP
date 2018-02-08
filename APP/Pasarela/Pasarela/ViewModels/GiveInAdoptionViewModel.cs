using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Breed;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.Dog;
using Pasarela.Core.Models.GiveInAdoption;
using Pasarela.Core.Models.PhotoDog;
using Pasarela.Core.Services.Breed;
using Pasarela.Core.Services.Dog;
using Pasarela.Core.Services.GiveInAdoption;
using Pasarela.Core.ViewModels.Base;
using Pasarela.Core.Views;
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
    public class GiveInAdoptionViewModel : ViewModelBase
    {

        private IBreedService _breedService;
        private IDogService _dogService;
        private IGiveInAdoptionService _giveInAdoptionService;
        private ObservableCollection<Breed> _breeds;
        private SaveDog _saveDog;
        private string _name;
        private Breed _selectedBreed;
        private string _selectedSex;
        private string _age;
        private string _description;
        private GiveInAdoption _saveGiveInAdoption;
        private List<SavePhotoDog> _photosDog = new List<SavePhotoDog>();
        public static GiveInAdoptionViewModel OLD_INSTANCE;
        public string photoDog;

        public GiveInAdoptionViewModel(IBreedService breedService, IDogService dogService, IGiveInAdoptionService giveInAdoptionService)
        {
            _breedService = breedService;
            _dogService = dogService;
            _giveInAdoptionService = giveInAdoptionService;
        }

        public ObservableCollection<Breed> ListBreed
        {
            get { return _breeds; }
            set
            {
                _breeds = value;
                RaisePropertyChanged(() => ListBreed);
            }
        }

        public GiveInAdoption SaveGiveInAdoption
        {
            get { return _saveGiveInAdoption; }
            set
            {
                _saveGiveInAdoption = value;
                RaisePropertyChanged(() => SaveGiveInAdoption);
            }
        }

        public SaveDog SaveDog
        {
            get { return _saveDog; }
            set
            {
                _saveDog = value;
                RaisePropertyChanged(() => SaveDog);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public Breed SelectedBreed
        {
            get { return _selectedBreed; }
            set
            {
                _selectedBreed = value;
                RaisePropertyChanged(() => SelectedBreed);
            }
        }

        public string SelectedSex
        {
            get { return _selectedSex; }
            set
            {
                _selectedSex = value;
                RaisePropertyChanged(() => SelectedSex);
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged(() => Age);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public List<SavePhotoDog> PhotosDog
        {
            get { return _photosDog; }
            set
            {
                _photosDog = value;
                RaisePropertyChanged(() => PhotosDog);
            }
        }

        public string ImageUser(string photo)
        {
            photoDog = photo;
            return photoDog;
        }

        public async override Task InitializeAsync(object navigationData)
        {
            var breed = await _breedService.GetAllBreedAsync();
            ListBreed = breed.ToObservableCollection();
            if (OLD_INSTANCE != null)
            {
                MessagingCenter.Unsubscribe<GiveInAdoptionView, string>(OLD_INSTANCE, MessageKeys.SendData);
            }

            OLD_INSTANCE = this;

            MessagingCenter.Subscribe<GiveInAdoptionView, string>(this, MessageKeys.SendData, (sender, args) =>
            {
                ImageUser(args);
                PhotosDog.Add(new SavePhotoDog { Photo = photoDog });
            });
        }

        public ICommand SaveCommand => new Command(async () => await SaveAsync());

        private async Task SaveAsync()
        {
            try
            {
                var saveDog = new SaveDog()
                {
                    IdUser = GlobalSetting.UserInfo.Id,
                    IdBreed = SelectedBreed.Id,
                    Name = Name,
                    Description = Description,
                    Age = Age,
                    Gender = SelectedSex
                  
                };
                await _dogService.SaveDogAsync(saveDog);

                var saveGiveInAdoption = new GiveInAdoption()
                {
                    IdUser = GlobalSetting.UserInfo.Id
                };
                await _giveInAdoptionService.SaveGiveInAdoptionAsync(saveGiveInAdoption);
                await _dogService.SavePhotoDogAsync(PhotosDog);
                await DialogService.ShowAlertAsync("Se registro con éxito su mascota en adopción", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

    }
}
