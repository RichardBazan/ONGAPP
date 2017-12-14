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
	public partial class RegisterUserView : ContentPage
	{
		public RegisterUserView ()
		{
			InitializeComponent ();
		}

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void DatePicker_DateSelected_1(object sender, DateChangedEventArgs e)
        {

        }
    }
}