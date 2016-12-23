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
using System.IO;
namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Pages.Rooms();
        }

        private void Rooms_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Rooms();
        }

        private void Suites_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Suites();
        }

        private void Ballroom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Ballrooms();
        }
    }
}
