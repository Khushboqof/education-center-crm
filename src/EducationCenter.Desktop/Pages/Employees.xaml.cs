using EducationCenter.Desktop.CrudPages;
using EducationCenter.Domain.Entities.Departments;
using EducationCenter.Service.DTOs.Departaments;
using EducationCenter.Service.Interfaces;
using EducationCenter.Service.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EducationCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        EmployeeCreatePage employeeCreatePage;
        EmployeeUpdatePage employeeUpdatePage;
        IEmployeeService employeeService;

        public Employees()
        {
            employeeCreatePage = new EmployeeCreatePage();
            employeeUpdatePage = new EmployeeUpdatePage();
            InitializeComponent();
            employeeService = new EmployeeService();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtGrid.ItemsSource = (await employeeService.GetAllAsync()).ToList();
        }

        private async void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var product = (Employee)dtGrid.SelectedItem;

            var isDelete = await employeeService.DeleteAsync(o => o.Id == product.Id);

            if (isDelete is true)
            {
                var items = await employeeService.GetAllAsync();
                dtGrid.ItemsSource = items.ToList();

                MessageBox.Show("Employee ochirildi!", "Success!");
            }
            else
                MessageBox.Show("Employee ochirilmadi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void UpdateBtn(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employeeUpdatePage.Visibility = Visibility.Visible;
            MainFrame.Content = employeeUpdatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            //CreateCourseBtn.Visibility = Visibility.Collapsed;
            UpdateBtn(sender, e);
            employeeUpdatePage.UpdateEmployeeButton.Click += UpdateButton_Click;
            employeeUpdatePage.CancelButton.Click += CancelUpdateButton_Click;
        }

        private void CreateCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeCreatePage.Visibility = Visibility.Visible;
            MainFrame.Content = employeeCreatePage;
            dtGrid.Visibility = Visibility.Collapsed;
            CreateEmployeeBtn.Visibility = Visibility.Collapsed;
            employeeCreatePage.CreateEmployeeButton.Click += CreateCourseButton_Click;
            employeeCreatePage.CancelButton.Click += CancelCreateButton_Click;
        }

        private void CancelCreateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;
            CreateEmployeeBtn.Visibility = Visibility.Visible;
            employeeCreatePage.Visibility = Visibility.Collapsed;
        }

        private void CancelUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.Visibility = Visibility.Visible;

            employeeUpdatePage.Visibility = Visibility.Collapsed;
        }


        private async void CreateCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeCreatePage.EmployeeName.Text) || string.IsNullOrEmpty(employeeCreatePage.EmployeeLast.Text) || string.IsNullOrEmpty(employeeCreatePage.EmployeeEmail.Text) || string.IsNullOrEmpty(employeeCreatePage.EmployeePhone.Text) || string.IsNullOrEmpty(employeeCreatePage.EmplyeePosition.Text))
            {
                MessageBox.Show("Bo'sh satrlarni to'ldiring!");
                return;
            }
            var course = new EmployeeForCreationDto
            {
                FirstName = employeeCreatePage.EmployeeName.Text,
                LastName = employeeCreatePage.EmployeeLast.Text,
                Email = employeeCreatePage.EmployeeEmail.Text,
                Phone = employeeCreatePage.EmployeePhone.Text,
                Position = employeeCreatePage.EmplyeePosition.Text
            };

            await employeeService.CreateAsync(course);

            MessageBox.Show("Created Successefully");

            dtGrid.Visibility = Visibility.Visible;
            CreateEmployeeBtn.Visibility = Visibility.Visible;
            employeeCreatePage.Visibility = Visibility.Collapsed;
            Page_Loaded(sender, e);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeUpdatePage.EmployeeName.Text) || string.IsNullOrEmpty(employeeUpdatePage.EmployeeLast.Text) || string.IsNullOrEmpty(employeeUpdatePage.EmployeeEmail.Text) || string.IsNullOrEmpty(employeeUpdatePage.EmployeePhone.Text) || string.IsNullOrEmpty(employeeUpdatePage.EmployeePosition.Text))
            {
                MessageBox.Show("Ma'lumotlarni to'liq kiriting!");
                return;
            }
            await employeeService.UpdateAsync(long.Parse(employeeUpdatePage.EmplyeeId.Text), new EmployeeForCreationDto
            {
                FirstName = employeeUpdatePage.EmployeeName.Text,
                LastName = employeeUpdatePage.EmployeeLast.Text,
                Email = employeeUpdatePage.EmployeeEmail.Text,
                Phone = employeeUpdatePage.EmployeePhone.Text,
                Position = employeeUpdatePage.EmployeePosition.Text,
            });

            employeeUpdatePage.EmplyeeId.Text = String.Empty;
            employeeUpdatePage.EmployeeName.Text = String.Empty;
            employeeUpdatePage.EmployeeLast.Text = String.Empty;
            employeeUpdatePage.EmployeeEmail.Text = String.Empty;
            employeeUpdatePage.EmployeePhone.Text = String.Empty;
            employeeUpdatePage.EmployeePosition.Text = String.Empty;



            MessageBox.Show("Ma'lumot yangilandi!");
            Page_Loaded(sender, e);
        }
    }
}
