using Xamarin.Forms;

namespace PassXYZ.UI
{
	public partial class HybridWebViewPage : ContentPage
	{
		public HybridWebViewPage ()
		{
			InitializeComponent ();

			hybridWebView.RegisterAction (data => DisplayAlert ("Alert", "Hello " + data, "OK"));
            // hybridWebView.Html = "<html><body>You scored <b>192</b> points.</body></html>";
        }
    }
}
