using PassXYZ.UI.Abstractions;
using PassXYZ.UI.Uwp;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebViewBaseUrl))]
namespace PassXYZ.UI.Uwp
{
    public class WebViewBaseUrl : IWebViewBaseUrl
    {
        public string Url
        {
            get { return "ms-appx-web:///Assets/"; }
        }
    }
}
