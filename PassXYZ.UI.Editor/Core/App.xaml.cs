using System;
using PassXYZ.UI.Abstractions;
using Xamarin.Forms;

namespace PassXYZ.UI.Editor
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new EditorPage(PassXYZ.UI.Editor.Properties.Resources.DefaultMarkdownText, "PassXYZ Editor"));
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
    }
}
