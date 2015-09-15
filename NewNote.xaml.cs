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

        private void clearTextBox(object sender, RoutedEventArgs e)
        {
            if (title.Text.Equals("Título", StringComparison.OrdinalIgnoreCase) && sender.Equals(title))
            {
                title.Text = string.Empty;
            }

            if (body.Text.Equals("Nota...", StringComparison.OrdinalIgnoreCase) && sender.Equals(body))
            {
                body.Text = string.Empty;
            }
        }
    }
}