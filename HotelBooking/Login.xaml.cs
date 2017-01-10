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
            //The source the the items in the combobox
            LoginCboBox.ItemsSource = loginManager.CapitalThemeNameList;
            //Initial item selected
            LoginCboBox.SelectedItem = "Sky";
            //Focus on the username to type easily
            UsernameTextBox.Focus();
        }

        private void LoginCboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Set to themeName so that the theme can change when logged in 
            themeName = LoginCboBox.SelectedValue.ToString();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "visitor" && PasswordTextBox.Password == "password")
            {
                ErrorMessage.Visibility = Visibility.Hidden; 
                //Close the Login window
                CloseEvent();
            }
            else
            {
                //Show invalid username or password when invalid credentials
                ErrorMessage.Visibility = Visibility.Visible;
                UsernameTextBox.Text = "";
                PasswordTextBox.Password = "";
                UsernameTextBox.Focus();
            }
        }

        //Check for if Enter is pressed to send the login request
        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginButton_Click(null, null);
            }
        }
    }
}
