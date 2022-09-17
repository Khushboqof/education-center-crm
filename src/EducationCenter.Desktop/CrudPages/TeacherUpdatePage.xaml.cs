using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace EducationCenter.Desktop.CrudPages
{
    /// <summary>
    /// Interaction logic for TeacherUpdatePage.xaml
    /// </summary>
    public partial class TeacherUpdatePage : Page
    {
        public TeacherUpdatePage()
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
