using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;
using System.Windows.Input;

namespace LMS.Views;

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
        var dialog = new EmployeeDialog();
        dialog.Owner = this;
        dialog.ShowDialog();

        RefreshData();
    }

    private void EmployeeDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var employee = EmployeeDataGrid.SelectedItem as Employee;

        if(employee  != null)
        {
            var dialog = new EmployeeDialog(employee);
            dialog.Owner = this;
            dialog.ShowDialog();

            RefreshData();
        }
    }

    private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
    {
        if(EmployeeDataGrid.SelectedItem is not Employee selectedEmployee)
        {
            MessageBox.Show(
                "Please, select an employee to delete",
                "Error",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
            return;
        }

        var isConfirm = MessageBox.Show(
            $"Are you sure to delete employee: {selectedEmployee.Ename}?",
            "Confirm your action!",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if(isConfirm != MessageBoxResult.Yes)
        {
            return;
        }

        var result = _databaseManager.DeleteEmployee(selectedEmployee.Empno);
        if (result)
        {
            RefreshData();
        }

    }

    private void RefreshData()
    {
        var employees = _databaseManager.GetEmployees();

        EmployeeDataGrid.ItemsSource = null;
        EmployeeDataGrid.ItemsSource = employees;
    }
}
