using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string themeName { get; set; }
        private ThemeManager loginManager = new ThemeManager();
        public delegate void CloseEventHandler();
        public event CloseEventHandler CloseEvent;

        public Login()
        {
            InitializeComponent();
            LoginCboBox.ItemsSource = loginManager.CapitalThemeNameList;
            LoginCboBox.SelectedItem = "Sky";
            UsernameTextBox.Focus();
        }

        private void LoginCboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            themeName = LoginCboBox.SelectedValue.ToString();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "visitor" && PasswordTextBox.Password == "password")
            {
                ErrorMessage.Visibility = Visibility.Hidden; 
                CloseEvent();
            }
            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
                UsernameTextBox.Text = "";
                PasswordTextBox.Password = "";
                UsernameTextBox.Focus();
            }
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginButton_Click(null, null);
            }
        }
    }
}
