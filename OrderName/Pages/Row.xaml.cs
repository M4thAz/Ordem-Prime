using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderName.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Row : ContentPage
	{

		public Row ()
		{
			InitializeComponent ();
		}

		private void BTNBackButton(object sender, EventArgs e)
		{
			Navigation.PushAsync(new MainPage());
	    }
	}
}
