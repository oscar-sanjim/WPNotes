using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPNotes.Resources;
using WPNotes.ViewModels;

namespace WPNotes
{
    public partial class MainPage : PhoneApplicationPage
    {
        

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            List<NoteModel> allList = new List<NoteModel>();
            List<NoteModel> featuredList = new List<NoteModel>();
            List<NoteModel> workList = new List<NoteModel>();
            List<NoteModel> personalList = new List<NoteModel>();


            DBController lst = new DBController();

            personalList = lst.GetCategoryNotes("Personal");
            personal.ItemsSource = personalList;

            workList = lst.GetCategoryNotes("Trabajo");
            work.ItemsSource = workList;

            featuredList = lst.GetFeaturedNotes();
            featured.ItemsSource = featuredList;

            allList = lst.WPNotes.ToList();
            allNotes.ItemsSource = allList;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DBController lst = new DBController();
            allNotes.ItemsSource = lst.WPNotes.ToList();
            personal.ItemsSource = lst.GetFeaturedNotes();
            work.ItemsSource = lst.GetCategoryNotes("Trabajo");
            personal.ItemsSource = lst.GetCategoryNotes("Personal");
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

        }


        // When element in the list is clicked
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector lls = sender as LongListSelector;
            NoteModel noteData = (NoteModel)lls.SelectedItem;

            String id = noteData.Id;

            NavigationService.Navigate(new Uri("/NewNote.xaml?id="+id, UriKind.Relative));
        }

        //Action Button for adding new note
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewNote.xaml", UriKind.Relative));
        }
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}