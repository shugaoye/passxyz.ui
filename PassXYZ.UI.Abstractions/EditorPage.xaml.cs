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

        public EditorPage(string text = " ", string title = " ") 
        {
            InitializeComponent();

            markdownEditor.Text = text;
            _text = text;
            Title = title;
        }

        async void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            _text = await markdownEditor.SaveOrEdit();
            if (_text != null)
            {
                // Need to save _text at here
                editButton.Text = "Edit";
                editButton.IconImageSource = "ic_passxyz_edit.png";
                Save(_text);
            }
            else 
            {
                editButton.Text = "Save";
                editButton.IconImageSource = "ic_passxyz_save.png";
                Debug.Print("Editing markdown text\n");
            }
        }

        bool Save(string text) 
        {
            Debug.Print("Saving markdown text\n");
            return true;
        }

    }
}