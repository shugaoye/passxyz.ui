using System;
using Xamarin.Forms;

namespace PassXYZ.UI.Droid
{
	public class MarkdownViewRenderer
	{
		public static void Init()
		{
			DependencyService.Register<WebViewBaseUrl>();
		}
	}
}
