using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Services.ShelterHouse;
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
    public class RegisterShelterHouseViewModel : ViewModelBase
    {

        private string _name;
        private string _address;
        private string _phone;
        private string _description;
        private SaveShelterHouse _saveShelterHouse;
        private IShelterHouseService _shelterHouseService;

        public RegisterShelterHouseViewModel(IShelterHouseService shelterHouseService)
        {
            _shelterHouseService = shelterHouseService;
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

        public SaveShelterHouse SaveShelterHouse
        {
            get { return _saveShelterHouse; }
            set
            {
                _saveShelterHouse = value;
                RaisePropertyChanged(() => SaveShelterHouse);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

        public ICommand SaveCommand => new Command(async () => await SaveAsync());

        private async Task SaveAsync()
        {
            try
            {
                var saveShelterHouse = new SaveShelterHouse()
                {
                    IdUser = 1,
                    Name = Name,
                    Description = Description,
                    Address=Address,
                    Phone=Phone
                };
                await _shelterHouseService.SaveShelterHouseAsync(saveShelterHouse);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

    }
}
