using Pasarela.Core.Extensions;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Complaints;
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
    public class AllComplaintsViewModel: ViewModelBase
    {
        private ObservableCollection<Complaints> _complaints;
        private IComplaintsService _complaintsService;

        public AllComplaintsViewModel(IComplaintsService complaintsService)
        {
            _complaintsService = complaintsService;
        }

        public ObservableCollection<Complaints> ListComplaints
        {
            get { return _complaints; }
            set
            {
                _complaints = value;
                RaisePropertyChanged(() => ListComplaints);
            }
        }

        public async override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var complaintsList = await _complaintsService.GetAllComplaintsAsync();
            ListComplaints = complaintsList.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand ViewDetailCommand => new Command(async (item) => await ViewDetailAsync(item));

        private async Task ViewDetailAsync(object item)
        {
            IsBusy = true;
            var complaints = item as Complaints;
            await NavigationService.NavigateToAsync<ComplaintDetailViewModel>(complaints);
            IsBusy = false;
        }

        public ICommand CommentsCommand => new Command(async (item) => await CommentsAsync(item));

        private async Task CommentsAsync(object item)
        {
            IsBusy = true;
            var complaints = item as Complaints;
            await NavigationService.NavigateToAsync<ComentComplaintsViewModel>(complaints);
            IsBusy = false;
        }
        
    }
}
