using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.ViewModels;
using Pasarela.Core.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pasarela.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = HomeView;
                        break;
                    case 1:
                        CurrentPage = ProfileView;
                        break;
                    case 2:
                        CurrentPage = BasketView;
                        break;
                }
            });

            await ((CatalogViewModel)HomeView.BindingContext).InitializeAsync(null);
            await ((BasketViewModel)BasketView.BindingContext).InitializeAsync(null);
            await ((ProfileViewModel)ProfileView.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is BasketView)
            {
                // Force basket view refresh every time we access it
                await (BasketView.BindingContext as ViewModelBase).InitializeAsync(null);
            }
        }
    }
}
