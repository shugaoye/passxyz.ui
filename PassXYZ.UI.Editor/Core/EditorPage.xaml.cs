using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassXYZ.UI.Editor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorPage : ContentPage
    {
        private string _text;
        public EditorPage()
        {
            InitializeComponent();

            markdownEditor.Text = Properties.Resources.DefaultMarkdownText;
            _text = Properties.Resources.DefaultMarkdownText;
            Title = "PassXYZ Introduction";
        }

        public EditorPage(string text, string title) 
        {
            InitializeComponent();

            markdownEditor.Text = text;
            _text = text;
            Title = title;
        }

        async void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            bool status = await IsPreviewActive();
            if(!status)
            {
                _text = await GetMarkdownText();
                editButton.Text = "Edit";
                editButton.IconImageSource = "ic_passxyz_edit.png";
                Debug.Print("Saving markdown text\n");
            }
            else 
            {
                editButton.Text = "Save";
                editButton.IconImageSource = "ic_passxyz_save.png";
                Debug.Print("Editing markdown text\n");
            }
            TogglePreview();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(EditorPage),
            defaultValue: default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); _text = value; }
        }

        public async Task<bool> IsPreviewActive()
        {
            var x = await markdownEditor.EvaluateJavaScriptAsync($"MyMDE.isPreviewActive();");
            if(x.Equals("true"))
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
            var x = await markdownEditor.EvaluateJavaScriptAsync($"MyMDE.value();");
            return x;
        }

        async void TogglePreview()
        {
            await markdownEditor.EvaluateJavaScriptAsync($"MyMDE.togglePreview();");
        }
    }
}