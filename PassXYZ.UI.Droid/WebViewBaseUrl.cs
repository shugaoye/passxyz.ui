using PassXYZ.UI.Abstractions;
using PassXYZ.UI.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(WebViewBaseUrl))]
namespace PassXYZ.UI.Droid
{
	public class WebViewBaseUrl : IWebViewBaseUrl
	{
		#region IWebViewBaseUrl implementation
		string IWebViewBaseUrl.Url {
			get {
				return "file:///android_asset/";
			}
		}
		#endregion
		
	}
}

