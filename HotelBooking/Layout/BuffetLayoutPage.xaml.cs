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
    /// Interaction logic for BuffetLayoutPage.xaml
    /// </summary>
    public partial class BuffetLayoutPage : Page
    {
        public BuffetLayoutPage()
        {
            InitializeComponent();
            SizeChanged += Classic_SizeChanged;
        }

        private void Classic_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //To change the template if certain width
            if (e.NewSize.Width < 1000)
            {
                //Set values for the displays in the template called BuffetShorterGrid
                BuffetShorterGrid buffetShorterGrid = new BuffetShorterGrid();
                Model model = Application.Current.Properties["PageData"] as Model;
                buffetShorterGrid.ItemName.Text = model.Name;
                buffetShorterGrid.ListTitle.Text = model.ListTitle;
                buffetShorterGrid.ItemDescription.Text = model.ItemDesc;
                buffetShorterGrid.ListDesc.ItemsSource = model.ListDesc;
                String stringPath = model.ImagePath;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                buffetShorterGrid.ItemImage.Source = imageBitmap;
                ContentHolder.Content = buffetShorterGrid;
            }
            else
            {
                //Set values for the displays in the template called BuffetLongerGrid
                BuffetLongerGrid buffetLongerGrid = new BuffetLongerGrid();
                Model model = Application.Current.Properties["PageData"] as Model;
                buffetLongerGrid.ItemName.Text = model.Name;
                buffetLongerGrid.ListTitle.Text = model.ListTitle;
                buffetLongerGrid.ItemDescription.Text = model.ItemDesc;
                buffetLongerGrid.ListDesc.ItemsSource = model.ListDesc;
                String stringPath = model.ImagePath;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                buffetLongerGrid.ItemImage.Source = imageBitmap;
                ContentHolder.Content = buffetLongerGrid;
            }
        }
    }
}
