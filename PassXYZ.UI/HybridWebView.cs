using System;
using Xamarin.Forms;

namespace PassXYZ.UI
{
	public class HybridWebView : View
	{
		Action<string> action;

        public static readonly BindableProperty IsUriSourceProperty = BindableProperty.Create(
            propertyName: "IsUriSource",
            returnType: typeof(bool),
            declaringType: typeof(HybridWebView),
            defaultValue: default(bool));

        public bool IsUriSource {
            get { return (bool)GetValue(IsUriSourceProperty); }
            set { SetValue(IsUriSourceProperty, value); }
        }

        public static readonly BindableProperty UriProperty = BindableProperty.Create (
			propertyName: "Uri",
			returnType: typeof(string),
			declaringType: typeof(HybridWebView),
			defaultValue: default(string));
		
		public string Uri {
			get { return (string)GetValue (UriProperty); }
			set { SetValue (UriProperty, value); IsUriSource = true; }
		}

        public static readonly BindableProperty BaseUrlProperty = BindableProperty.Create(
            propertyName: "BaseUrl",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string BaseUrl
        {
            get { return (string)GetValue(BaseUrlProperty); }
            set { SetValue(BaseUrlProperty, value); }
        }

        public static readonly BindableProperty HtmlProperty = BindableProperty.Create(
            propertyName: "Html",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string Html
        {
            get { return (string)GetValue(HtmlProperty); }
            set { SetValue(HtmlProperty, value); ; IsUriSource = false; }
        }

        public void RegisterAction (Action<string> callback)
		{
			action = callback;
		}

		public void Cleanup ()
		{
			action = null;
		}

		public void InvokeAction (string data)
		{
			if (action == null || data == null) {
				return;
			}
			action.Invoke (data);
		}
	}
}
