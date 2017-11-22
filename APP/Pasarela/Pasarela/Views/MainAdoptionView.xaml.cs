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
    public partial class MainAdoptionView : TabbedPage
    {
        public MainAdoptionView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainAdoptionViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = MyAdoptionsView;
                        break;
                    case 1:
                        CurrentPage = AdoptView;
                        break;
                    case 2:
                        CurrentPage = AllAdoptionsView;
                        break;
                }
            });

            await ((MyAdoptionsViewModel)MyAdoptionsView.BindingContext).InitializeAsync(null);
            await ((AdoptViewModel)AdoptView.BindingContext).InitializeAsync(null);
            await ((AllAdoptionsViewModel)AllAdoptionsView.BindingContext).InitializeAsync(null);
        }
    }
}