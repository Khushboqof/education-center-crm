using EducationCenter.Desktop.Windows;
using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Service.DTOs.Courses;
using EducationCenter.Service.Interfaces;
using EducationCenter.Service.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EducationCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Page
    {
        CourseUpdateWindow courseUpdateWindow;
        CourseCreatePage courseCreatePage;
        ICourseService courseService;

        public Courses()
        {
            courseCreatePage = new CourseCreatePage();
            courseUpdateWindow = new CourseUpdateWindow();
            InitializeComponent();
            courseService = new CourseService();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtGrid.ItemsSource = (await courseService.GetAllAsync()).ToList();
        }

        private async void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var product = (Course)dtGrid.SelectedItem;

            var isDelete = await courseService.DeleteAsync(o => o.Id == product.Id);

            if (isDelete is true)
            {
                var items = await courseService.GetAllAsync();
                dtGrid.ItemsSource = items.ToList();

                MessageBox.Show("Course ochirildi!", "Success!");
            }
            else
                MessageBox.Show("Course ochirilmadi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void UpdateBtn(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            courseUpdateWindow.Visibility = Visibility.Visible;
            MainFrame.Content = courseUpdateWindow;
            dtGrid.Visibility = Visibility.Collapsed;
            //CreateCourseBtn.Visibility = Visibility.Collapsed;
            UpdateBtn(sender, e);
            courseUpdateWindow.UpdateCourseButton.Click += UpdateButton_Click;
            courseUpdateWindow.CancelButton.Click += CancelUpdateButton_Click;
        }

        private void CreateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            courseCreatePage.Visibility = Visibility.Visible;
            MainFrame.Content = courseCreatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            CreateCourseBtn.Visibility = Visibility.Collapsed;
            courseCreatePage.CreateCourseButton.Click += CreateCourseButton_Click;
            courseCreatePage.CancelButton.Click += CancelCreateButton_Click;
        }

        private void CancelCreateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;
            CreateCourseBtn.Visibility = Visibility.Visible;
            courseCreatePage.Visibility = Visibility.Collapsed;
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;

            courseUpdateWindow.Visibility = Visibility.Collapsed;
        }


        private async void CreateCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseCreatePage.CourseName.Text) || string.IsNullOrEmpty(courseCreatePage.CoursePrice.Text) || string.IsNullOrEmpty(courseCreatePage.CourceDuration.Text))
            {
                MessageBox.Show("Bo'sh satrlarni to'ldiring!");
                return;
            }
            var course = new CourseForCreationDto
            {
                Name = courseCreatePage.CourseName.Text,
                Price = decimal.Parse(courseCreatePage.CoursePrice.Text),
                Duration = ushort.Parse(courseCreatePage.CourceDuration.Text),
            };

            await courseService.CreateAsync(course);

            MessageBox.Show("Created Successefully");

            dtGrid.Visibility = Visibility.Visible;
            CreateCourseBtn.Visibility = Visibility.Visible;
            courseCreatePage.Visibility = Visibility.Collapsed;
            Page_Loaded(sender, e);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(courseUpdateWindow.CourseId.Text) || string.IsNullOrEmpty(courseUpdateWindow.CourseName.Text) || string.IsNullOrEmpty(courseUpdateWindow.CoursePrice.Text) || string.IsNullOrEmpty(courseUpdateWindow.CourseDuration.Text))
            {
                MessageBox.Show("Ma'lumotlarni to'liq kiriting!");
                return;
            }
            await courseService.UpdateAsync(long.Parse(courseUpdateWindow.CourseId.Text), new CourseForCreationDto
            {
                Name = courseUpdateWindow.CourseName.Text,
                Price = decimal.Parse(courseUpdateWindow.CoursePrice.Text),
                Duration = ushort.Parse(courseUpdateWindow.CourseDuration.Text)
            });

            courseUpdateWindow.CourseId.Text = String.Empty;
            courseUpdateWindow.CourseName.Text = String.Empty;
            courseUpdateWindow.CoursePrice.Text = String.Empty;
            courseUpdateWindow.CourseDuration.Text = String.Empty;

            MessageBox.Show("Ma'lumot yangilandi!");
            Page_Loaded(sender, e);
        }
    }
}
