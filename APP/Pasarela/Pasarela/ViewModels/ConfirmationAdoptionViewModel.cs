using Pasarela.Core.Models.Adoption;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.Dog;
using Pasarela.Core.Services.Adoption;
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
    public class ConfirmationAdoptionViewModel: ViewModelBase
    {

        private Dog _dog;
        private IAdoptionService _adoptionService;

        public ConfirmationAdoptionViewModel(IAdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        public Dog Dog
        {
            get { return _dog; }
            set
            {
                _dog = value;
                RaisePropertyChanged(() => Dog);
            }
        }


        public async override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as Dog;
            Dog = data;
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

        public ICommand AceptCommand => new Command(async () => await AceptAsync());

        private async Task AceptAsync()
        {
            try
            {
                var saveAdoption = new Adoption()
                {
                    IdUser = 2,
                    IdDog= Dog.Id
                };
                await _adoptionService.SaveAdoptionAsync(saveAdoption);
                await DialogService.ShowAlertAsync("Se solicitó con éxito su adopción", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
                await NavigationService.NavigateBack(false);
                await NavigationService.NavigateBack(false);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

    }
}
