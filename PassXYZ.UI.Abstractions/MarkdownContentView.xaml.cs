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
    public partial class MarkdownContentView : ContentView
    {
        public MarkdownContentView()
        {
            InitializeComponent();

            markdownView.Markdown = "Please take your notes.";
            markdownView.VerticalOptions = LayoutOptions.FillAndExpand;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(MarkdownContentView),
            defaultValue: default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { markdownView.Markdown = value; SetValue(TextProperty, value); }
        }

    }
}