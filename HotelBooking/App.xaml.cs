using System.Windows;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Login login = new Login();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            login.CloseEvent += Login_CloseEvent;
            login.Show();
        }

        private void Login_CloseEvent()
        {
            MainWindow main = new MainWindow();
            main.Show();
            login.Close();
        }
    }
}