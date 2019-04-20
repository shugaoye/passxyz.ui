﻿using Xamarin.Forms;

namespace PassXYZ.UI
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new HybridWebViewPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
