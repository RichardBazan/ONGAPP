using Android.Widget;
using Pasarela.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
namespace Pasarela.Droid.Renderers
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                var image = toolbar.FindViewById<ImageView>(Resource.Id.toolbar_image);

                if (Element.CurrentPage == null)
                {
                    return;
                }

                if (!string.IsNullOrEmpty(Element.CurrentPage.Title))
                    image.Visibility = Android.Views.ViewStates.Invisible;
                else
                    image.Visibility = Android.Views.ViewStates.Visible;
            }
        }
    }
}