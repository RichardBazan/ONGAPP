using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Breed;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Services.Breed;
using Pasarela.Core.Services.Complaints;
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
    public class RegisterComplaintViewModel : ViewModelBase
    {
        private IBreedService _breedService;
        private ObservableCollection<Breed> _breeds;
        private string _title;
        private string _address;
        private string _phone;
        private string _description;
        private IComplaintsService _complaintsService;
        private Breed _selectedBreed;

        public RegisterComplaintViewModel(IBreedService breedService, IComplaintsService complaintsService)
        {
            _breedService = breedService;
            _complaintsService = complaintsService;
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

        public Breed SelectedBreed
        {
            get { return _selectedBreed; }
            set
            {
                _selectedBreed = value;
                RaisePropertyChanged(() => SelectedBreed);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                RaisePropertyChanged(() => Address);
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged(() => Phone);
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

        public async override Task InitializeAsync(object navigationData)
        {
            var breed = await _breedService.GetAllBreedAsync();
            ListBreed = breed.ToObservableCollection();
        }

        public ICommand SaveCommand => new Command(async () => await SaveAsync());

        private async Task SaveAsync()
        {
            try
            {
                var saveComplaints = new SaveComplaints()
                {
                    
                    IdUser = 2,
                    IdBreed = SelectedBreed.Id,
                    Title = Title,
                    Description = Description,
                    State = "1",
                    Address = Address,
                    Phone = Phone,
                };
                await _complaintsService.SaveComplaintsAsync(saveComplaints);
                await DialogService.ShowAlertAsync("Se registro con éxito la denuncia", Constants.MessageTitle.Message, Constants.MessageButton.OK);
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
