
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.User;
using Pasarela.Core.ViewModels.Base;
using Pasarela.Core.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class MyDataViewModel : ViewModelBase
    {
        private UserInfo _userInfo;
        private ImageSource _photoUser;
        private bool _disable;
        public static MyDataViewModel OLD_INSTANCE;
        public string photoUser;
        private UserUpdate _userUpdate;
        private IUserService _userService;

        public MyDataViewModel(IUserService userService)
        {
            _userService = userService;
            Disable = false;
        }

        public ImageSource PhotoUser
        {
            get { return _photoUser; }
            set
            {
                _photoUser = value;
                RaisePropertyChanged(() => PhotoUser);
            }
        }


        public bool Disable
        {
            get { return _disable; }
            set
            {
                _disable = value;
                RaisePropertyChanged(() => Disable);
            }
        }
        public UserInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                _userInfo = value;
                RaisePropertyChanged(() => UserInfo);
            }
        }

        public UserUpdate UserUpdate
        {
            get
            {
                return _userUpdate;
            }
            set
            {
                _userUpdate = value;
                RaisePropertyChanged(() => UserUpdate);
            }
        }

        public string ImageUser(string photo)
        {
            photoUser = photo;
            return photoUser;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            if (OLD_INSTANCE != null)
            {
                MessagingCenter.Unsubscribe<MyDataView, string>(OLD_INSTANCE, MessageKeys.SendData);
            }

            OLD_INSTANCE = this;

            MessagingCenter.Subscribe<MyDataView, string>(this, MessageKeys.SendData, (sender, args) =>
            {
                ImageUser(args);
            });
            UserInfo = GlobalSetting.UserInfo;
            string p = GlobalSetting.UserInfo.Photo;
            p = p.Substring(23);
            var bytes = Convert.FromBase64String(p);
            Stream contents = new MemoryStream(bytes);
            PhotoUser = ImageSource.FromStream(() => { return contents; });
            IsBusy = false;
        }

        public ICommand EditCommand => new Command(async () => await EditAsync());

        private async Task EditAsync()
        {
            IsBusy = true;
            Disable = true;
            IsBusy = false;
        }

        public ICommand CameraCommand => new Command(async () => await CameraAsync());

        private async Task CameraAsync()
        {
            MessageHelper.OpenCameraData();
        }

        public ICommand UpdateCommand => new Command(async () => await UpdateAsync());

        private async Task UpdateAsync()
        {
            try
            {

                var updateUser = new UserInfo()
                {
                    Name = UserInfo.Name,
                    FirstLastName = UserInfo.FirstLastName,
                    SecondLastName = UserInfo.SecondLastName,
                    Birthdate = UserInfo.Birthdate,
                    Address = UserInfo.Address,
                    Phone = UserInfo.Phone,
                    UserName = UserInfo.UserName,
                    Photo = photoUser
                };

                await _userService.UpdateUserAsync(GlobalSetting.UserInfo.Id, updateUser);
                await DialogService.ShowAlertAsync("Se actualizó con éxito", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

    }
}
