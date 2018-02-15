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
        private List<SavePhotoShelterHouse> _photosShelterHouse = new List<SavePhotoShelterHouse>();
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

        public List<SavePhotoShelterHouse> PhotosShelterHouse
        {
            get { return _photosShelterHouse; }
            set
            {
                _photosShelterHouse = value;
                RaisePropertyChanged(() => PhotosShelterHouse);
            }
        }

        public string ImageUser(string photo)
        {
            photoShelterHouse = photo;
            return photoShelterHouse;
        }


        public override async Task InitializeAsync(object navigationData)
        {
            if (OLD_INSTANCE != null)
            {
                MessagingCenter.Unsubscribe<RegisterShelterHouseView, string>(OLD_INSTANCE, MessageKeys.SendDataShelterHouse);
            }

            OLD_INSTANCE = this;

            MessagingCenter.Subscribe<RegisterShelterHouseView, string>(this, MessageKeys.SendDataShelterHouse, (sender, args) =>
            {
                PhotosShelterHouse.Add(new SavePhotoShelterHouse { Photo = args });
            });
        }

        public ICommand CameraCommand => new Command(async () => await CameraAsync());

        private async Task CameraAsync()
        {
            MessageHelper.OpenCameraShelterHouse();
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
            if (Name != null && Description != null && Address != null && Address != null && Phone != null && Name != "" && Description  != "" && Address != "" && Phone != "" )
            {
                try
                {
                    var saveShelterHouse = new SaveShelterHouse()
                    {
                        IdUser = GlobalSetting.UserInfo.Id,
                        Name = Name,
                        Description = Description,
                        Address = Address,
                        Phone = Phone
                    };
                    await _shelterHouseService.SaveShelterHouseAsync(saveShelterHouse);
                    //var savePhotoShelterHouse = new List<SavePhotoShelterHouse>()
                    //{
                    //    Photo= PhotosShelterHouse
                    //};
                    await _shelterHouseService.SavePhotoShelterHouseAsync(PhotosShelterHouse);
                    await DialogService.ShowAlertAsync("Se registro con éxito la casa refugio", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                    await NavigationService.NavigateBack(false);
                }
                catch (Exception ex)
                {
                    await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Message, Constants.MessageButton.OK);
                }
            }
            else
            {
                await DialogService.ShowAlertAsync("Complete todos los campos para poder registrar la casa refugio", Constants.MessageTitle.Message, Constants.MessageButton.OK);
            }
            }
    }
}
