using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;

using MessageBox = LMS.Extensions.MessageBoxExtensions;

namespace LMS.Views;

/// <summary>
/// Interaction logic for DepartmentWindow.xaml
/// </summary>
public partial class DepartmentWindow : Window
{
    private readonly DepartmentManagement _departmentManager;

    public DepartmentWindow()
    {
        InitializeComponent();

        _departmentManager = new DepartmentManagement();
        var departments = _departmentManager.GetDepartments();

        DepartmentDataGrid.ItemsSource = departments;
    }

    private void AddDepartment_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new DepartmentDialog();
        dialog.Owner = this;
        dialog.ShowDialog();

        RefreshData();
    }

    private void DepartmentDataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
        var department = DepartmentDataGrid.SelectedItem as Department;

        if(department != null)
        {
            var dialog = new DepartmentDialog(department);
            dialog.Owner = this;
            dialog.ShowDialog();

            RefreshData();
        }
        
    }

    private void DeleteDepartment_Click(object sender, RoutedEventArgs e)
    {
        if(DepartmentDataGrid.SelectedItem is not Department selectedDepartment)
        {
            MessageBox.ShowError("Please, select a department to delete");
            return;
        }

        var isConfirm = MessageBox.ShowConfirmation("Are you sure to delete this department");

        if(isConfirm != MessageBoxResult.Yes)
        {
            return;
        }

        try
        {
            var result = _departmentManager.DeleteDepartment(selectedDepartment.Number);
            if (result)
            {
                RefreshData();
            }
        }
        catch(Exception ex)
        {
            MessageBox.ShowError($"There was an error while deleting a department. \nDetails: {ex.Message}");
        }
    }

    private void RefreshData()
    {
        try
        {
            var departments = _departmentManager.GetDepartments();

            DepartmentDataGrid.ItemsSource = null;
            DepartmentDataGrid.ItemsSource = departments;
        }
        catch(Exception ex)
        {
            MessageBox.ShowError($"There was an error while loading data. \nDetails: {ex.Message}");
        }
    }
}
