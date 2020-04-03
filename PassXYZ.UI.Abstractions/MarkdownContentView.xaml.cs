using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        enum MarkdownEditorStatus 
        {
            Save,
            Edit,
            Back
        }

        public MarkdownEditor()
        {
            InitializeComponent();

            markdownView.Markdown = "Please take your notes.";
            markdownView.VerticalOptions = LayoutOptions.FillAndExpand;

            markdownView.Navigated += (sender, e) => { Debug.Print("Navigated"); };
            markdownView.Navigating += (sender, e) => { Debug.Print("Navigating"); };
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
        /// <returns>(bool Status, string Text)</returns>
        /// Status - return true, if the page is MarkdownEditor Page, false, if it is not the one.
        /// Text - Markdown text
        public async Task<(bool Status, string Text)> SaveOrEdit()
        {
            string _text = null;
            MarkdownEditorStatus status = await IsPreviewActive();
            if (status == MarkdownEditorStatus.Back) 
            {
                markdownView.GoBack();
                return (false, _text);
            }

            if (status == MarkdownEditorStatus.Save)
            {
                // Get the text that need to be saved
                _text = await GetMarkdownText();
            }
            TogglePreview();
            return (true, _text);
        }

        async Task<MarkdownEditorStatus> IsPreviewActive()
        {
            var x = await markdownView.EvaluateJavaScriptAsync($"MyMDE.isPreviewActive();");
            if(x != null) 
            {
                if (x.Equals("true"))
                {
                    return MarkdownEditorStatus.Edit;
                }
                else
                {
                    return MarkdownEditorStatus.Save;
                }
            }
            else 
            {
                return MarkdownEditorStatus.Back;
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