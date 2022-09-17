using EducationCenter.Desktop.CrudPages;
using EducationCenter.Domain.Entities.Students;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TestEducationCenterUoW.Service.DTOs.Students;
using TestEducationCenterUoW.Service.Interfaces;
using TestEducationCenterUoW.Service.Services;

namespace EducationCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        StudenUpdatePage studenUpdatePage;
        StudentCreatePage studentCreatePage;
        IStudentService studentService;

        public Students()
        {
            studenUpdatePage = new StudenUpdatePage();
            studentCreatePage = new StudentCreatePage();
            InitializeComponent();
            studentService = new StudentService();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtGrid.ItemsSource = (await studentService.GetAllAsync()).ToList();
        }

        private async void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var product = (Student)dtGrid.SelectedItem;

            var isDelete = await studentService.DeleteAsync(o => o.Id == product.Id);

            if (isDelete is true)
            {
                var items = await studentService.GetAllAsync();
                dtGrid.ItemsSource = items.ToList();

                MessageBox.Show("Student ochirildi!", "Success!");
            }
            else
                MessageBox.Show("Student ochirilmadi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void UpdateBtn(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studenUpdatePage.Visibility = Visibility.Visible;
            MainFrame.Content = studenUpdatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            //CreateCourseBtn.Visibility = Visibility.Collapsed;
            UpdateBtn(sender, e);
            studenUpdatePage.UpdateStudentButton.Click += UpdateButton_Click;
            studenUpdatePage.CancelButton.Click += CancelUpdateButton_Click;
        }

        private void CreateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            studentCreatePage.Visibility = Visibility.Visible;
            MainFrame.Content = studentCreatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            CreateStudentBtn.Visibility = Visibility.Collapsed;
            studentCreatePage.CreateStudentButton.Click += CreateCourseButton_Click;
            studentCreatePage.CancelButton.Click += CancelCreateButton_Click;
        }

        private void CancelCreateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;
            CreateStudentBtn.Visibility = Visibility.Visible;
            studentCreatePage.Visibility = Visibility.Collapsed;
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;

            studenUpdatePage.Visibility = Visibility.Collapsed;
        }


        private async void CreateCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(studentCreatePage.StudentName.Text) || string.IsNullOrEmpty(studentCreatePage.StudentLast.Text) || string.IsNullOrEmpty(studentCreatePage.StudentPhone.Text) || string.IsNullOrEmpty(studentCreatePage.CourseId.Text))
            {
                MessageBox.Show("Bo'sh satrlarni to'ldiring!");
                return;
            }
            var course = new StudentForCreationDto
            {
                FirstName = studentCreatePage.StudentName.Text,
                LastName = studentCreatePage.StudentLast.Text,
                Phone = studentCreatePage.StudentPhone.Text,
                CourseId = long.Parse(studentCreatePage.CourseId.Text)
            };

            await studentService.CreateAsync(course);

            MessageBox.Show("Successefully Created");

            dtGrid.Visibility = Visibility.Visible;
            CreateStudentBtn.Visibility = Visibility.Visible;
            studentCreatePage.Visibility = Visibility.Collapsed;
            Page_Loaded(sender, e);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(studenUpdatePage.StudentLast.Text) || string.IsNullOrEmpty(studenUpdatePage.StudentName.Text) || string.IsNullOrEmpty(studenUpdatePage.Phone.Text) || string.IsNullOrEmpty(studenUpdatePage.CourseId.Text))
            {
                MessageBox.Show("Ma'lumotlarni to'liq kiriting!");
                return;
            }
            await studentService.UpdateAsync(long.Parse(studenUpdatePage.studentId.Text), new StudentForCreationDto
            {
                FirstName = studenUpdatePage.StudentName.Text,
                LastName = studenUpdatePage.StudentLast.Text,
                Phone = studenUpdatePage.Phone.Text,
                CourseId = long.Parse(studenUpdatePage.CourseId.Text)
            });

            studenUpdatePage.studentId.Text = String.Empty;
            studenUpdatePage.StudentName.Text = String.Empty;
            studenUpdatePage.StudentLast.Text = String.Empty;
            studenUpdatePage.Phone.Text = String.Empty;
            studenUpdatePage.CourseId.Text = String.Empty;


            MessageBox.Show("Ma'lumot yangilandi!");
            Page_Loaded(sender, e);
        }
    }
}

