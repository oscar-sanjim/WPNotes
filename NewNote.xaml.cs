using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPNotes.ViewModels;
using Microsoft.Phone.Tasks;

namespace WPNotes
{
    public partial class NewNote : PhoneApplicationPage
    {
        DBController lst;

        String id = null;
        public NewNote()
        {
            InitializeComponent();
            lst = new DBController();
        }


        /*
            * Function used to clear default text 
            * textBoxes when user tries to add data
        */
        private void clearTextBox(object sender, RoutedEventArgs e)
        {
            //Clearing Title textBox
            if (title.Text.Equals("Título", StringComparison.OrdinalIgnoreCase) && sender.Equals(title))
            {
                title.Text = string.Empty;
            }

            //Clearing body textBox
            if (body.Text.Equals("Nota...", StringComparison.OrdinalIgnoreCase) && sender.Equals(body))
            {
                body.Text = string.Empty;
            }
        }


        //When landing on New Note page 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string checkID = "";

            //Obtaining the ID
            if (NavigationContext.QueryString.TryGetValue("id", out checkID))
            {
                id = checkID;
                //MessageBox.Show(checkID);
                header.Text = "Modificar Nota";
                NoteModel fill = lst.GetNoteInfo(id);
                title.Text = fill.Title;
                body.Text = fill.Body;
                featured.IsChecked = fill.Featured;
                if(fill.Category.Equals("Trabajo"))
                    category.SelectedItem = work;
                else
                    category.SelectedItem = personal;
                //MessageBox.Show(lst.GetNoteInfo(id).ToString());
            }
            else {
                id = null;
                //deleteButton.Content = "Cancelar";
                header.Text = "Agregar Nota";
            }
        }

        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            
            lst.Agregar(getNoteInfo());
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private NoteModel getNoteInfo()
        {
            bool fea = featured.IsChecked.Value;
            ListPickerItem a = (ListPickerItem) category.SelectedItem;
            //MessageBox.Show(a.Content.ToString());
            if (id!= null)
                return new NoteModel(id,title.Text, a.Content.ToString(), body.Text, DateTime.Now, fea);
            else
                return new NoteModel(title.Text,a.Content.ToString(),body.Text,DateTime.Now,fea);

           
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {
                lst.DeleteNote(id);
                MessageBox.Show("La nota ha sido borrada");
            }
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void shareButton_Click(object sender, RoutedEventArgs e)
        {
            ShareStatusTask sst = new ShareStatusTask();
            sst.Status = title.Text +" - "+ body.Text;
            sst.Show();
        }
    }
}