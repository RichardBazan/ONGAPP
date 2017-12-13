using Pasarela.Core.Models.Dog;
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

        public ConfirmationAdoptionViewModel()
        {

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

    }
}
