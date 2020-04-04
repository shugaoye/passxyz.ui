﻿using System;
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
        private static int pageCount = 0;
        private bool isBack = false;

        public EditorPage(string text = " ", string title = " ") 
        {
            InitializeComponent();

            markdownEditor.Text = text;
            _text = text;
            Title = title;
            markdownEditor.NavigatedHandler = EditorPageNavigated;
        }

        void EditorPageNavigated(object sender, WebNavigatedEventArgs e)
        {
            if(isBack)
            {
                isBack = false;
                Debug.Print("Go back to an old page\n");
            }
            else 
            {
                editButton.Text = "Back";
                pageCount++;
                Debug.Print("Go to a new page, page count:" + pageCount.ToString() + ".\n");
            }            
        }

        async void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            if(markdownEditor.CanGoBack) 
            {
                markdownEditor.GoBack();
                isBack = true;
                pageCount = pageCount - 1;
                if (pageCount == 0)
                {
                    editButton.Text = "Edit";
                    Debug.Print("This is the home page, page count:" + pageCount.ToString() + ".\n");
                }
                else 
                {
                    editButton.Text = "Back";
                    Debug.Print("It is not home page, page count:" + pageCount.ToString() + ".\n");
                }
            }
            else 
            {
                var result = await markdownEditor.SaveOrEdit();
                if (result.Status)
                {
                    // If the result is from MarkdownEditor
                    _text = result.Text;
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
            }
        }

        bool Save(string text) 
        {
            Debug.Print("Saving markdown text\n");
            return true;
        }

    }
}