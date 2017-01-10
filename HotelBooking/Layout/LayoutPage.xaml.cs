using HotelBooking.Facility;
using HotelBooking.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelBooking.Layout
{
    /// <summary>
    /// Interaction logic for LayoutPage.xaml
    /// </summary>
    public partial class LayoutPage : Page
    {
        public LayoutPage()
        {
            InitializeComponent();
            SizeChanged += Classic_SizeChanged;
        }

        private void Classic_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //To change the template if certain width
            if (e.NewSize.Width < 1000)
            {
                //Set values for the displays in the template called ShorterGrid
                ShorterGrid shorterGrid = new ShorterGrid();
                Model model = Application.Current.Properties["PageData"] as Model;
                shorterGrid.ItemName.Text = model.Name;
                shorterGrid.ListTitle.Text = model.ListTitle;
                shorterGrid.ItemDescription.Text = model.ItemDesc;
                shorterGrid.ListDesc.ItemsSource = model.ListDesc;
                String stringPath = model.ImagePath;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                shorterGrid.ItemImage.Source = imageBitmap;
                ContentHolder.Content = shorterGrid;
            }
            else
            {
                //Set values for the displays in the template called ShorterGrid
                LongerGrid longerGrid = new LongerGrid();
                Model model = Application.Current.Properties["PageData"] as Model;
                longerGrid.ItemName.Text = model.Name;
                longerGrid.ListTitle.Text = model.ListTitle;
                longerGrid.ItemDescription.Text = model.ItemDesc;
                longerGrid.ListDesc.ItemsSource = model.ListDesc;
                String stringPath = model.ImagePath;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                longerGrid.ItemImage.Source = imageBitmap;
                ContentHolder.Content = longerGrid;
            }
        }
    }
}