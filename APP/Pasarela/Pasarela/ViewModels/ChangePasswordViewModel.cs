using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.User;
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
    public class ChangePasswordViewModel : ViewModelBase
    {
        private ChangePassword _changePassword;
        private string _passwordActual;
        private string _passwordConfirm;
        private string _passwordNew;
        private IUserService _userService;

        public ChangePasswordViewModel(IUserService userService)
        {
            _userService = userService;
        }


        public ChangePassword ChangePassword
        {
            get
            {
                return _changePassword;
            }
            set
            {
                _changePassword = value;
                RaisePropertyChanged(() => ChangePassword);
            }
        }

        public string PasswordActual
        {
            get
            {
                return _passwordActual;
            }
            set
            {
                _passwordActual = value;
                RaisePropertyChanged(() => PasswordActual);
            }
        }

        public string PasswordNew
        {
            get
            {
                return _passwordNew;
            }
            set
            {
                _passwordNew = value;
                RaisePropertyChanged(() => PasswordNew);
            }
        }

        public string PasswordConfirm
        {
            get
            {
                return _passwordConfirm;
            }
            set
            {
                _passwordConfirm = value;
                RaisePropertyChanged(() => PasswordConfirm);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public ICommand ChangeCommand => new Command(async () => await ChangeAsync());

        private async Task ChangeAsync()
        {
            IsBusy = true;
            if (GlobalSetting.UserInfo.Password == PasswordActual)
            {
                if (PasswordNew == PasswordConfirm)
                {
                    var changepassword = new ChangePassword()
                    {
                        PasswordActual = PasswordActual,
                        PasswordNew = PasswordNew
                    };
                    await _userService.UpdatePasswordAsync(GlobalSetting.UserInfo.Id, changepassword);
                    await DialogService.ShowAlertAsync("Se actualizó la contraseña correctamente", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                }
                else
                {
                    await DialogService.ShowAlertAsync("Las contraseña no coinciden", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                }
            }
            else
            {
                await DialogService.ShowAlertAsync("Tu contraseña actual no es la correcta", Constants.MessageTitle.Message, Constants.MessageButton.OK);
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
