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
    public partial class MainShelterHouseView : TabbedPage
    {
        public MainShelterHouseView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainShelterHouseViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    //case 0:
                    //    CurrentPage = MyShelterHouseView;
                    //    break;
                    case 0:
                        CurrentPage = RegisterShelterHouseView;
                        break;
                    case 1:
                        CurrentPage = AllShelterHouseView;
                        break;
                }
            });

            //await ((MyShelterHouseViewModel)MyShelterHouseView.BindingContext).InitializeAsync(null);
            await ((RegisterShelterHouseViewModel)RegisterShelterHouseView.BindingContext).InitializeAsync(null);
            await ((AllShelterHouseViewModel)AllShelterHouseView.BindingContext).InitializeAsync(null);
        }
    }
}