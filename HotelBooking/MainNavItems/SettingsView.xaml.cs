using System.Windows.Controls;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private ThemeManager manager = new ThemeManager();

        public SettingsView()
        {
            InitializeComponent();
            //Give combobox a list of values for selection by user
            cboTheme.ItemsSource = manager.CapitalThemeNameList;
            //Set initial value of combobox
            cboTheme.SelectedItem = Login.themeName;
        }

        private void cboTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Call for set theme method in ThemeManager
            manager.SetTheme(cboTheme.SelectedValue.ToString().ToLower());
        }
    }
}
