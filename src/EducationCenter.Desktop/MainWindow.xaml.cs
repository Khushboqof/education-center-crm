using EducationCenter.Desktop.Pages;
using System.Windows;
using System.Windows.Navigation;

namespace EducationCenter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            //    if (Themes.IsChecked == true)
            //        //ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            //    else
            //        //ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Students());
        }

        private void rdAnalytics_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Teachers());
        }

        private void rdMessages_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Employees());
        }

        private void rdCollections_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Courses());
        }

        private void rdUsers_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Groups());
        }

        private void frameContent_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void rdHome_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new AboutUs());

        }
    }
}
