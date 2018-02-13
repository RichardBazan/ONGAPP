using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.User;
using Pasarela.Core.ViewModels.Base;
using Pasarela.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class RegisterUserViewModel : ViewModelBase
    {

        private string _name;
        private string _firstLastName;
        private string _secondLastName;
        private string _address;
        private string _phone;
        private DateTime _birthdate;
        private string _user;
        private string _password;
        private string _passwordConfirm;
        private IUserService _userService;
        public static RegisterUserViewModel OLD_INSTANCE;
        public string photoUser;

        public RegisterUserViewModel(IUserService userService)
        {
            _userService = userService;
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

        public string FirstLastName
        {
            get { return _firstLastName; }
            set
            {
                _firstLastName = value;
                RaisePropertyChanged(() => FirstLastName);
            }
        }

        public string SecondLastName
        {
            get { return _secondLastName; }
            set
            {
                _secondLastName = value;
                RaisePropertyChanged(() => SecondLastName);
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

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
                RaisePropertyChanged(() => Birthdate);
            }
        }

        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                RaisePropertyChanged(() => PasswordConfirm);
            }
        }
        void DatePicker_DateSelected()
        {

        }

        public string ImageUser(string photo)
        {
            photoUser = photo;
            return photoUser;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (OLD_INSTANCE != null)
            {
                MessagingCenter.Unsubscribe<RegisterUserView, string>(OLD_INSTANCE, MessageKeys.SendDataUser);
            }

            OLD_INSTANCE = this;

            MessagingCenter.Subscribe<RegisterUserView, string>(this, MessageKeys.SendDataUser, (sender, args) =>
            {
                ImageUser(args);
            });
        }

        public ICommand CameraCommand => new Command(async () => await CameraAsync());

        private async Task CameraAsync()
        {
            MessageHelper.OpenCameraUser();
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

            if (Password == PasswordConfirm && Password != null)
            {
                if (Name != null && FirstLastName != null && SecondLastName != null && Address != null && Phone != null && User != null && Password != null && Name != "" && FirstLastName != "" && SecondLastName != "" && Address != "" && Phone != "" && User != "" && Password != "" && photoUser != null && photoUser != "" )
                {
                    try
                    {

                        var saveUser = new User()
                        {
                            Name = Name,
                            FirstLastName = FirstLastName,
                            SecondLastName = SecondLastName,
                            Birthdate = Birthdate,
                            Address = Address,
                            Phone = Phone,
                            UserName = User,
                            Password = Password,
                            Photo = photoUser
                        };

                        await _userService.SaveUserAsync(saveUser);
                        await DialogService.ShowAlertAsync("Se registro con éxito", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                        await NavigationService.NavigateBack(false);
                    }
                    catch (Exception ex)
                    {
                        await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
                    }

                }
                else
                {
                    await DialogService.ShowAlertAsync("Complete todos los campos para poder registrarse", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                }
            }
            else
            {
                await DialogService.ShowAlertAsync("Las contraseñas no coinciden", Constants.MessageTitle.Message, Constants.MessageButton.OK);
            }
        }
    }
}

