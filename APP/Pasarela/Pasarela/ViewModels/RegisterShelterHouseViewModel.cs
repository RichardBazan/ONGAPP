using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.PhotoShelterHouse;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Services.ShelterHouse;
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
    public class RegisterShelterHouseViewModel : ViewModelBase
    {

        private string _name;
        private string _address;
        private string _phone;
        private string _description;
        private SaveShelterHouse _saveShelterHouse;
        private IShelterHouseService _shelterHouseService;
        private List<PhotoShelterHouse> _photosShelterHouse;
        public static RegisterShelterHouseViewModel OLD_INSTANCE;
        public string photoShelterHouse;

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

        public List<PhotoShelterHouse> PhotosShelterHouse
        {
            get { return _photosShelterHouse; }
            set
            {
                _photosShelterHouse = value;
                RaisePropertyChanged(() => PhotosShelterHouse);
            }
        }

        public List<PhotoShelterHouse> ImageUser(string photo)
        {
            photoShelterHouse = photo;
            PhotosShelterHouse.Add(new PhotoShelterHouse { Photo = photoShelterHouse});
            return PhotosShelterHouse;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (OLD_INSTANCE != null)
            {
                MessagingCenter.Unsubscribe<RegisterShelterHouseView, string>(OLD_INSTANCE, MessageKeys.SendData);
            }

            MessagingCenter.Subscribe<RegisterShelterHouseView, string>(this, MessageKeys.SendData, (sender, args) =>
            {
                ImageUser(args);
            });
        }

        public ICommand CameraCommand => new Command(async () => await CameraAsync());

        private async Task CameraAsync()
        {
            MessageHelper.OpenCameraMessage();
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
                    IdUser = GlobalSetting.UserInfo.Id,
                    Name = Name,
                    Description = Description,
                    Address=Address,
                    Phone=Phone
                };
                await _shelterHouseService.SaveShelterHouseAsync(saveShelterHouse);
                var savePhotoShelterHouse = new SavePhotoShelterHouse()
                {
                    Photos= PhotosShelterHouse
                };
                await _shelterHouseService.SavePhotoShelterHouseAsync(savePhotoShelterHouse);
                await DialogService.ShowAlertAsync("Se registro con éxito la casa refugio", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

    }
}
