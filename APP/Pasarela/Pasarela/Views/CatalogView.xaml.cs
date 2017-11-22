using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.ViewModels;
using Pasarela.Core.ViewModels.Base;
using SlideOverKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pasarela.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogView : ContentPage, IMenuContainerPage
    {
        private FiltersView _filterView = new FiltersView();

        public CatalogView()
        {
            InitializeComponent();

            SlideMenu = _filterView;

            MessagingCenter.Subscribe<CatalogViewModel>(this, MessageKeys.Filter, (sender) =>
            {
                Filter();
            });
        }

        public Action HideMenuAction
        {
            get;
            set;
        }

        public Action ShowMenuAction
        {
            get;
            set;
        }

        public SlideMenuView SlideMenu
        {
            get;
            set;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _filterView.BindingContext = BindingContext;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            if (SlideMenu.IsShown)
            {
                HideMenuAction?.Invoke();
            }
            else
            {
                ShowMenuAction.Invoke();
            }
        }
    }
}