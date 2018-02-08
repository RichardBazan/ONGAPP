using Pasarela.Core.ViewModels;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pasarela.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainConfigurationView : TabbedPage
    {
        public MainConfigurationView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainConfigurationViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = MyDataView;
                        break;
                    case 1:
                        CurrentPage = ChangePasswordView;
                        break;
                }
            });

            await ((MyDataViewModel)MyDataView.BindingContext).InitializeAsync(null);
            await ((ChangePasswordViewModel)ChangePasswordView.BindingContext).InitializeAsync(null);
        }
    }
}