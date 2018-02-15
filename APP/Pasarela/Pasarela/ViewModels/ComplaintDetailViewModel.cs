using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Models.PhotoComplaints;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private ObservableCollection<PhotoComplaintsDetail> _listPhotos = new ObservableCollection<PhotoComplaintsDetail>();

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

        public ObservableCollection<PhotoComplaintsDetail> ListPhotos
        {
            get { return _listPhotos; }
            set
            {
                _listPhotos = value;
                RaisePropertyChanged(() => ListPhotos);
            }
        }

        public async override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as Complaints;
            Complaints = data;
            foreach (var item in Complaints.Photos)
            {
                //if (item.Photos.Count == 0)
                //{
                //    item.Photos.Add(new Models.PhotoDog.PhotoDog() { Photo = "ic_default" });
                //}
                var photo = item.Photo;
                photo = photo.Substring(23);
                byte[] bytes = Convert.FromBase64String(photo);
                Stream contents = new MemoryStream(bytes);
                var photoDetail = ImageSource.FromStream(() => { return contents; });
                ListPhotos.Add(new PhotoComplaintsDetail { PhotoDetail = photoDetail });
            }
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
