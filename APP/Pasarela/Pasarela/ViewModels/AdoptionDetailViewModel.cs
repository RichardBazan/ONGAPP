using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Dog;
using Pasarela.Core.Models.PhotoDog;
using Pasarela.Core.Services.Dog;
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
    public class AdoptionDetailViewModel : ViewModelBase
    {
        private Dog _dog;
        private bool _visible;
        private ObservableCollection<PhotoDogDetail> _listPhotos = new ObservableCollection<PhotoDogDetail>();

        public AdoptionDetailViewModel()
        {
            Visible = true;
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


        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                RaisePropertyChanged(() => Visible);
            }
        }

        public ObservableCollection<PhotoDogDetail> ListPhotos
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
            var data = navigationData as Dog;
            Dog = data;
            if(Dog.State.Equals("En Adopcion"))
            {
                Visible = true;
            }
            else if (Dog.State.Equals("Adoptado"))
            {
                Visible = false;
            }
            foreach (var item in Dog.Photos)
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
                ListPhotos.Add(new PhotoDogDetail { PhotoDetail = photoDetail });
            }
        }

        public ICommand AdoptCommand => new Command(async () => await AdoptAsync());

        private async Task AdoptAsync()
        {
            IsBusy = true;
            if(Dog.Tenure.Equals("Usuario"))
            { 
            await NavigationService.NavigateToAsync<ConfirmationAdoptionViewModel>(Dog);
            }
            else
            {
                await NavigationService.NavigateToAsync<ConfirmationAdoptionOngViewModel>(Dog);
            }
            IsBusy = false;
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
