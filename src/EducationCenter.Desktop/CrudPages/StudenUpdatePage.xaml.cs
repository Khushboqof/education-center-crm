using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace EducationCenter.Desktop.CrudPages
{
    /// <summary>
    /// Interaction logic for StudenUpdatePage.xaml
    /// </summary>
    public partial class StudenUpdatePage : Page
    {
        public StudenUpdatePage()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
