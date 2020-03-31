using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassXYZ.UI.Editor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorPage : ContentPage
    {
        public EditorPage()
        {
            InitializeComponent();

            markdownEditor.Text = Properties.Resources.DefaultMarkdownText;
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            // messageLabel.Text = $"You clicked the \"{item.Text}\" toolbar item.";
        }
    }
}