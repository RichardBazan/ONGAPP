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
    public partial class MainAbuseView : TabbedPage
    {
        public MainAbuseView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainAbuseViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
                switch (arg)
                {
                    case 0:
                        CurrentPage = MyComplaintsView;
                        break;
                    case 1:
                        CurrentPage = RegisterComplaintView;
                        break;
                    case 2:
                        CurrentPage = AllComplaintsView;
                        break;
                }
            });

            await ((MyComplaintsViewModel)MyComplaintsView.BindingContext).InitializeAsync(null);
            await ((RegisterComplaintViewModel)RegisterComplaintView.BindingContext).InitializeAsync(null);
            await ((AllComplaintsViewModel)AllComplaintsView.BindingContext).InitializeAsync(null);
        }
    }
}