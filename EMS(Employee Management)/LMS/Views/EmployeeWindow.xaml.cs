using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;
using System.Windows.Input;

using MessageBox = LMS.Extensions.MessageBoxExtensions;
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
            MessageBox.ShowError($"Please, select an employee to delete");
            return;
        }

        var isConfirm = MessageBox.ShowConfirmation($"Are you sure to delete this employee: {selectedEmployee.Name}");

        if(isConfirm != MessageBoxResult.Yes)
        {
            return;
        }

        try
        {
            var result = _databaseManager.DeleteEmployee(selectedEmployee.Number);
            if (result)
            {
                RefreshData();
            }
        }
        catch(Exception ex)
        {
            MessageBox.ShowError($"There was an error while deleting an employee.\nDetails: {ex.Message}");
        }

    }

    private void RefreshData()
    {
        try
        {
            var employees = _databaseManager.GetEmployees();

            EmployeeDataGrid.ItemsSource = null;
            EmployeeDataGrid.ItemsSource = employees;
        }
        catch(Exception ex)
        {
            MessageBox.ShowError($"There was an error while loading data.\nDetails: {ex.Message}");
        }
    }
}
