using Pasarela.Core.Models.Complaints;
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
    public class ComplaintDetailViewModel: ViewModelBase
    {
        private Complaints _complaints;

        public ComplaintDetailViewModel()
        {

        }

        public Complaints Complaints
        {
            get { return _complaints; }
            set
            {
                _complaints = value;
                RaisePropertyChanged(() => Complaints);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as Complaints;
            Complaints = data;
            return base.InitializeAsync(navigationData);
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

        public ICommand CommentsCommand => new Command(async () => await CommentsAsync());

        private async Task CommentsAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<ComentComplaintsViewModel>(Complaints);
            IsBusy = false;
        }

    }
}
