using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Helpers;
using Pasarela.Core.ViewModels.Base;
using Pasarela.Services;
using Xamarin.Forms;

namespace Pasarela
{
    public partial class App : Application
    {
        public bool UseMockServices { get; set; }

        public App()
        {
            InitializeComponent();

            InitApp();

            if (Device.RuntimePlatform == Device.WinPhone)
            {
                InitNavigation();
            }
        }

        private void InitApp()
        {
            UseMockServices = Settings.UseMocks;
            ViewModelLocator.RegisterDependencies(UseMockServices);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform != Device.WinPhone)
            {
                await InitNavigation();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
