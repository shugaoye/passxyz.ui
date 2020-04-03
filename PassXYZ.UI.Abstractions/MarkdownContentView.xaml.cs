using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassXYZ.UI.Abstractions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarkdownEditor : ContentView
    {
        public MarkdownEditor()
        {
            InitializeComponent();

            markdownView.Markdown = "Please take your notes.";
            markdownView.VerticalOptions = LayoutOptions.FillAndExpand;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(MarkdownEditor),
            defaultValue: default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { markdownView.Markdown = value; SetValue(TextProperty, value); }
        }

        /// <summary>
        /// This function check the current status and return a modified text or toggle to preview mode.
        /// If a "Save" button is clicked, the view should be changed to preview mode and save the text.
        /// If a "Edit" button is clicked, the view should be changed to editing mode and return null.
        /// </summary>
        /// <returns></returns>
        public async Task<string> SaveOrEdit()
        {
            string _text = null;
            bool status = await IsPreviewActive();
            if (!status)
            {
                // Get the text that need to be saved
                _text = await GetMarkdownText();
            }
            TogglePreview();
            return _text;
        }

        async Task<bool> IsPreviewActive()
        {
            var x = await markdownView.EvaluateJavaScriptAsync($"MyMDE.isPreviewActive();");
            if (x.Equals("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async Task<string> GetMarkdownText()
        {
            var x = await markdownView.EvaluateJavaScriptAsync($"MyMDE.value();");
            return x;
        }

        async void TogglePreview()
        {
            await markdownView.EvaluateJavaScriptAsync($"MyMDE.togglePreview();");
        }

        public Task<string> EvaluateJavaScriptAsync(string script)
        {
            return markdownView.EvaluateJavaScriptAsync(script);
        }
    }
}