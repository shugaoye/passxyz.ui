using Foundation;
using PassXYZ.UI.Abstractions;
using PassXYZ.UI.iOS;
using Xamarin.Forms;

namespace PassXYZ.UI.iOS
{


	public class WebViewBaseUrl : IWebViewBaseUrl
	{
		#region IWebViewBaseUrl implementation
		public string Url {
			get {
				return Foundation.NSBundle.MainBundle.BundlePath + "/";
			}
		}
		#endregion
	}
}

