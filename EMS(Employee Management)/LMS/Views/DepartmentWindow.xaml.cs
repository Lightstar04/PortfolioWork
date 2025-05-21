using LMS.Data;
using LMS.Dialogs;
using LMS.Models;
using System.Windows;

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
            MessageBox.Show(
                "Please, select a department to delete!",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        var isConfirm = MessageBox.Show(
            $"Are you sure to delete this department: {selectedDepartment.Dname}",
            "Confirm your action!",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if(isConfirm != MessageBoxResult.Yes)
        {
            return;
        }

        var result = _departmentManager.DeleteDepartment(selectedDepartment.Deptno);
        if (result)
        {
            RefreshData();
        }
    }

    private void RefreshData()
    {
        var departments = _departmentManager.GetDepartments();

        DepartmentDataGrid.ItemsSource = null;
        DepartmentDataGrid.ItemsSource = departments;
    }
}
