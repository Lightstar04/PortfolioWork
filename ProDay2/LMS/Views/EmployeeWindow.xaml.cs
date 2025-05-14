using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;

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
            var window = new AddEmployeeDialog();
            window.ShowDialog();
        }
    }
}
