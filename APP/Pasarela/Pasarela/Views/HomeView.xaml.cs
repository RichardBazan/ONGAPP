using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pasarela.Core.Views
{
    public class BannerRotatorSimulator
    {
        public static float SWIPE_INTERVAL = 5f;

        public bool HasEnded;
        public int CurrentIndex;
        public SfRotator CurrentRotator;

        private BannerRotatorSimulator(SfRotator rotator)
        {
            HasEnded = false;
            CurrentIndex = 0;
            CurrentRotator = rotator;
            CurrentRotator.SelectedIndexChanged += OnSelectedIndexChanged;

            Device.StartTimer(TimeSpan.FromSeconds(SWIPE_INTERVAL), OnTimerLoop);
        }

        public void RemoveBindings()
        {
            CurrentRotator.SelectedIndexChanged -= OnSelectedIndexChanged;
        }

        private bool OnTimerLoop()
        {
            if (!HasEnded)
            {
                var itemCount = CurrentRotator.ItemsSource.Count();
                CurrentIndex = CurrentRotator.SelectedIndex;

                CurrentRotator.SelectedIndex = (CurrentIndex + 1) >= itemCount
                    ? 0
                    : (CurrentIndex + 1);
                CurrentIndex = CurrentRotator.SelectedIndex;
            }
            else { RemoveBindings(); }

            return !HasEnded;
        }

        private void OnSelectedIndexChanged(object sender, SelectedIndexChangedEventArgs e)
        {
            HomeView.REMOVE_LAST_SIMULATOR();
            // Create new instance if the selected index changed, this is the only way to reset the time (No way to control the Device.StartTimer)
            HomeView.CURRENT_ROTATORS.Add(BannerRotatorSimulator.Create(this.CurrentRotator));
        }


        public static BannerRotatorSimulator Create(SfRotator rotator) { return new BannerRotatorSimulator(rotator); }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private static bool ALREADY_INSTANCED = false;
        public static List<BannerRotatorSimulator> CURRENT_ROTATORS = null;

        public HomeView()
        {
            InitializeComponent();

            // static for banner
            if (!HomeView.ALREADY_INSTANCED)
            {
                HomeView.CURRENT_ROTATORS = new List<BannerRotatorSimulator>();
                HomeView.ALREADY_INSTANCED = true;
            }

            HomeView.REMOVE_LAST_SIMULATOR();
            HomeView.CURRENT_ROTATORS.Add(BannerRotatorSimulator.Create(this.rotator));
        }

        #region Static Methods

        public static void REMOVE_LAST_SIMULATOR()
        {
            var oldInstance = HomeView.CURRENT_ROTATORS.FirstOrDefault();

            if (oldInstance != null)
            {
                oldInstance.RemoveBindings();
                oldInstance.HasEnded = true;
                HomeView.CURRENT_ROTATORS.RemoveAt(0);
            }
        }
        #endregion


    }
}