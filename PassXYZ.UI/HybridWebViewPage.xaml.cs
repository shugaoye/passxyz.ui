using Xamarin.Forms;

namespace PassXYZ.UI
{
	public partial class HybridWebViewPage : ContentPage
	{
		public HybridWebViewPage ()
		{
			InitializeComponent ();

			hybridWebView.RegisterAction (data => DisplayAlert ("Alert", "Hello " + data, "OK"));
		}
	}
}
