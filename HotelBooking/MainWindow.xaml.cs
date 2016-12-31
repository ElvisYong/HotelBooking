using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ThemeManager manager = new ThemeManager();
        Page rooms = new Pages.Rooms();
        Page ballrooms = new Pages.Ballrooms();
        Page buffets = new Pages.Buffets();

        public MainWindow()
        {
            InitializeComponent();
            Main.Source = new Uri("/HotelBooking;component/Pages/Rooms.xaml", UriKind.Relative);
            cboTheme.ItemsSource = manager.CapitalThemeNameList;
            cboTheme.SelectedItem = Login.themeName;
        }

        private void Rooms_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Source = new Uri("/HotelBooking;component/Pages/Rooms.xaml", UriKind.Relative);
        }

        private void Ballroom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Source = new Uri("/HotelBooking;component/Pages/Ballrooms.xaml", UriKind.Relative);
        }

        private void Buffet_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Source = new Uri("/HotelBooking;component/Pages/Buffets.xaml", UriKind.Relative);
        }

        private void cboTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.SetTheme(cboTheme.SelectedValue.ToString().ToLower());
        }
    }
}
