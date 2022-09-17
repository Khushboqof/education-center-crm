using EducationCenter.Service.Interfaces;
using EducationCenter.Service.Services;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace EducationCenter.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CourseUpdateWindow.xaml
    /// </summary>
    public partial class CourseUpdateWindow : Page
    {
        ICourseService courseService;

        public CourseUpdateWindow()
        {
            courseService = new CourseService();
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
