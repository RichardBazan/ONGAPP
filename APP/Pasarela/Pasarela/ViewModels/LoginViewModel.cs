using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IdentityModel.Client;
using Pasarela.Core;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.User;
using Pasarela.Core.Services.Identity;
using Pasarela.Core.Services.OpenUrl;
using Pasarela.Core.Validations;
using Pasarela.Core.ViewModels.Base;
using Xamarin.Forms;
using Pasarela.Core.Services.User;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //private ValidatableObject<string> _userName;
        //private ValidatableObject<string> _password;
        private bool _isMock;
        private bool _isValid;
        private bool _isLogin;
        private string _authUrl;

        private IOpenUrlService _openUrlService;
        private IIdentityService _identityService;

        private IUserService _userService;
        private string _userName;
        private string _password;

        public LoginViewModel(
            IOpenUrlService openUrlService,
            IIdentityService identityService,
            IUserService userService)
        {
            _openUrlService = openUrlService;
            _identityService = identityService;
            _userService = userService;

            //_userName = new ValidatableObject<string>();
            //_password = new ValidatableObject<string>();

            InvalidateMock();
            //AddValidations();
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsMock
        {
            get
            {
                return _isMock;
            }
            set
            {
                _isMock = value;
                RaisePropertyChanged(() => IsMock);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }
            set
            {
                _isLogin = value;
                RaisePropertyChanged(() => IsLogin);
            }
        }

        public string LoginUrl
        {
            get
            {
                return _authUrl;
            }
            set
            {
                _authUrl = value;
                RaisePropertyChanged(() => LoginUrl);
            }
        }

        public ICommand MockSignInCommand => new Command(async () => await MockSignInAsync());

        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

        public ICommand NavigateCommand => new Command<string>(async (url) => await NavigateAsync(url));

        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        //public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        //public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is LogoutParameter)
            {
                var logoutParameter = (LogoutParameter)navigationData;

                if (logoutParameter.Logout)
                {
                    Logout();
                }
            }

            return base.InitializeAsync(navigationData);
        }

        private async Task MockSignInAsync()
        {
            try
            {
                await _userService.GetUserInfoAsync(UserName, Password);
                await NavigationService.NavigateToAsync<HomeViewModel>();
                await NavigationService.RemoveLastFromBackStackAsync();
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }



        }

        private async Task SignInAsync()
        {
            IsBusy = true;

            await Task.Delay(500);

            LoginUrl = _identityService.CreateAuthorizationRequest();

            IsValid = true;
            IsLogin = true;
            IsBusy = false;
        }

        private void Register()
        {
            _openUrlService.OpenUrl(GlobalSetting.Instance.RegisterWebsite);
        }

        private void Logout()
        {
            var authIdToken = Settings.AuthIdToken;

            var logoutRequest = _identityService.CreateLogoutRequest(authIdToken);

            if (!string.IsNullOrEmpty(logoutRequest))
            {
                // Logout
                LoginUrl = logoutRequest;
            }

            if (Settings.UseMocks)
            {
                Settings.AuthAccessToken = string.Empty;
                Settings.AuthIdToken = string.Empty;
            }
        }

        private async Task NavigateAsync(string url)
        {
            var unescapedUrl = System.Net.WebUtility.UrlDecode(url);

            if (unescapedUrl.Equals(GlobalSetting.Instance.LogoutCallback))
            {
                Settings.AuthAccessToken = string.Empty;
                Settings.AuthIdToken = string.Empty;
                IsLogin = false;
                LoginUrl = _identityService.CreateAuthorizationRequest();
            }
            else if (unescapedUrl.Contains(GlobalSetting.Instance.IdentityCallback))
            {
                var authResponse = new AuthorizeResponse(url);

                if (!string.IsNullOrWhiteSpace(authResponse.AccessToken))
                {
                    if (authResponse.AccessToken != null)
                    {
                        Settings.AuthAccessToken = authResponse.AccessToken;
                        Settings.AuthIdToken = authResponse.IdentityToken;

                        await NavigationService.NavigateToAsync<HomeViewModel>();
                        await NavigationService.RemoveLastFromBackStackAsync();
                    }
                }
            }
        }

        private async Task SettingsAsync()
        {
            await NavigationService.NavigateToAsync<SettingsViewModel>();
        }

        //private bool Validate()
        //{
        //    bool isValidUser = ValidateUserName();
        //    bool isValidPassword = ValidatePassword();

        //    return isValidUser && isValidPassword;
        //}

        //private bool ValidateUserName()
        //{
        //    return _userName.Validate();
        //}

        //private bool ValidatePassword()
        //{
        //    return _password.Validate();
        //}

        //private void AddValidations()
        //{
        //    _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Ingrese su nombre de usuario." });
        //    _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Ingrese su contraseña." });
        //}

        public void InvalidateMock()
        {
            IsMock = Settings.UseMocks;
        }

        private async Task RegisterAsync()
        {
            IsBusy = true;
            await NavigationService.NavigateToAsync<RegisterUserViewModel>();
            IsBusy = false;
        }
    }
}