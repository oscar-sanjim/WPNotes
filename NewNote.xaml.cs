using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WPNotes
{
    public partial class NewNote : PhoneApplicationPage
    {
        public NewNote()
        {
            InitializeComponent();
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
                MessageBox.Show(checkID);
                header.Text = "Modificar Nota";
            }
            else {
                header.Text = "Agregar Nota";
            }
        }
    }
}