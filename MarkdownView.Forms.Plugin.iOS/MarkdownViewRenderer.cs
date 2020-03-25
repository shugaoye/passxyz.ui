using System;
using Xamarin.Forms;

namespace PassXYZ.UI.iOS
{
	public class MarkdownViewRenderer
	{
		public static void Init()
		{
			DependencyService.Register<WebViewBaseUrl>();
		}
	}
}
