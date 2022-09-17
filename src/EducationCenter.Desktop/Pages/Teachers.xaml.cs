using EducationCenter.Desktop.CrudPages;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Service.DTOs.Teachers;
using EducationCenter.Service.Interfaces;
using EducationCenter.Service.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EducationCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Teachers.xaml
    /// </summary>
    public partial class Teachers : Page
    {
        TeacherCreatePage teacherCreatePage;
        TeacherUpdatePage teacherUpdatePage;
        ITeacherService teacherService;

        public Teachers()
        {
            teacherUpdatePage = new TeacherUpdatePage();
            teacherCreatePage = new TeacherCreatePage();
            InitializeComponent();
            teacherService = new TeacherService();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtGrid.ItemsSource = (await teacherService.GetAllAsync()).ToList();
        }

        private async void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var product = (Teacher)dtGrid.SelectedItem;

            var isDelete = await teacherService.DeleteAsync(o => o.Id == product.Id);

            if (isDelete is true)
            {
                var items = await teacherService.GetAllAsync();
                dtGrid.ItemsSource = items.ToList();

                MessageBox.Show("Teacher ochirildi!", "Success!");
            }
            else
                MessageBox.Show("TEacher ochirilmadi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void UpdateBtn(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teacherUpdatePage.Visibility = Visibility.Visible;
            MainFrame.Content = teacherUpdatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            //CreateCourseBtn.Visibility = Visibility.Collapsed;
            UpdateBtn(sender, e);
            teacherUpdatePage.UpdateTeacherButton.Click += UpdateButton_Click;
            teacherUpdatePage.CancelButton.Click += CancelUpdateButton_Click;
        }

        private void CreateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            teacherCreatePage.Visibility = Visibility.Visible;
            MainFrame.Content = teacherCreatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            CreateTeacherBtn.Visibility = Visibility.Collapsed;
            teacherCreatePage.CreateTeacherButton.Click += CreateCourseButton_Click;
            teacherCreatePage.CancelButton.Click += CancelCreateButton_Click;
        }

        private void CancelCreateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;
            CreateTeacherBtn.Visibility = Visibility.Visible;
            teacherCreatePage.Visibility = Visibility.Collapsed;
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;

            teacherUpdatePage.Visibility = Visibility.Collapsed;
        }


        private async void CreateCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(teacherCreatePage.TeacherName.Text) || string.IsNullOrEmpty(teacherCreatePage.TeacherLast.Text) || string.IsNullOrEmpty(teacherCreatePage.TeacherEmail.Text) || string.IsNullOrEmpty(teacherCreatePage.TeacherPhone.Text))
            {
                MessageBox.Show("Bo'sh satrlarni to'ldiring!");
                return;
            }
            var course = new TeacherForCreationDto
            {
                FirstName = teacherCreatePage.TeacherName.Text,
                LastName = teacherCreatePage.TeacherLast.Text,
                Email = teacherCreatePage.TeacherEmail.Text,
                PhoneNumber = teacherCreatePage.TeacherPhone.Text
            };

            await teacherService.CreateAsync(course);

            MessageBox.Show("Created Successefully");

            dtGrid.Visibility = Visibility.Visible;
            CreateTeacherBtn.Visibility = Visibility.Visible;
            teacherCreatePage.Visibility = Visibility.Collapsed;
            Page_Loaded(sender, e);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(teacherUpdatePage.TeacherName.Text) || string.IsNullOrEmpty(teacherUpdatePage.TeacherLast.Text) || string.IsNullOrEmpty(teacherUpdatePage.TacherEmail.Text) || string.IsNullOrEmpty(teacherUpdatePage.Phone.Text))
            {
                MessageBox.Show("Ma'lumotlarni to'liq kiriting!");
                return;
            }
            await teacherService.UpdateAsync(long.Parse(teacherUpdatePage.TeacherId.Text), new TeacherForCreationDto
            {
                FirstName = teacherUpdatePage.TeacherName.Text,
                LastName = teacherUpdatePage.TeacherLast.Text,
                Email = teacherUpdatePage.TacherEmail.Text,
                PhoneNumber = teacherUpdatePage.Phone.Text
            });

            teacherUpdatePage.TeacherId.Text = String.Empty;
            teacherUpdatePage.TeacherName.Text = String.Empty;
            teacherUpdatePage.TeacherLast.Text = String.Empty;
            teacherUpdatePage.TacherEmail.Text = String.Empty;
            teacherUpdatePage.Phone.Text = String.Empty;


            MessageBox.Show("Ma'lumot yangilandi!");
            Page_Loaded(sender, e);
        }
    }
}

