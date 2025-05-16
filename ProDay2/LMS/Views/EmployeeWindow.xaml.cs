using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;
using System.Windows.Input;

namespace LMS.Views
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {

        private readonly EmployeeManagement _databaseManager;
        public EmployeeWindow()
        {
            InitializeComponent();

            _databaseManager = new EmployeeManagement();
            var employees = _databaseManager.GetEmployees();

            EmployeeDataGrid.ItemsSource = employees;

        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEmployeeDialog();
            dialog.Owner = this;
            dialog.ShowDialog();

            var employees = _databaseManager.GetEmployees();

            EmployeeDataGrid.ItemsSource = null;
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void EmployeeDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var employee = EmployeeDataGrid.SelectedItem as Employee;

            var dialog = new AddEmployeeDialog(employee);
            dialog.Owner = this;
            dialog.ShowDialog();
        }
    }
}
