using Pasarela.Core.Models.PhotoShelterHouse;
using Pasarela.Core.Models.ShelterHouse;
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
    public class ShelterHouseDetailViewModel : ViewModelBase
    {
        private ShelterHouse _shelterHouse;
        private ObservableCollection<PhotoShelterHouseDetail> _listPhotos = new ObservableCollection<PhotoShelterHouseDetail>();

        public ShelterHouseDetailViewModel()
        {

        }

        public ShelterHouse ShelterHouse
        {
            get { return _shelterHouse; }
            set
            {
                _shelterHouse = value;
                RaisePropertyChanged(() => ShelterHouse);
            }
        }

        public ObservableCollection<PhotoShelterHouseDetail> ListPhotos
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
            var data = navigationData as ShelterHouse;
            ShelterHouse = data;
            foreach (var item in ShelterHouse.Photos)
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
                ListPhotos.Add(new PhotoShelterHouseDetail { PhotoDetail = photoDetail });
            }
        }

        public ICommand CancelCommand => new Command(async () => await CancelAsync());

        private async Task CancelAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateBack();
            IsBusy = false;
        }

        public ICommand DonateCommand => new Command(async () => await DonateAsync());

        private async Task DonateAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<DonateViewModel>(ShelterHouse);
            IsBusy = false;
        }

    }
}
