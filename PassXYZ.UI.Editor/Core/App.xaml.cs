﻿using System;
using PassXYZ.UI.Abstractions;
using Xamarin.Forms;

namespace PassXYZ.UI.Editor
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var _webView = new MarkdownEditor
			{
				Text = Md
			};
			MainPage = new ContentPage()
			{
				// Accomodate iPhone status bar.
				// Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Content = _webView
			};
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
		private string Md = PassXYZ.UI.Editor.Properties.Resources.DefaultMarkdownText;

    }
}
