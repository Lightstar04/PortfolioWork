using LMS.Data;
using LMS.Models;
using System.Windows;

namespace LMS.Dialogs;

/// <summary>
/// Interaction logic for AddDepartmentDialog.xaml
/// </summary>
public partial class DepartmentDialog : Window
{
    private readonly DepartmentManagement _departmentManager;
    private readonly bool isEditingMode;

    public DepartmentDialog()
    {
        InitializeComponent();

        _departmentManager = new DepartmentManagement();
    }

    public DepartmentDialog(Department department)
        :this()
    {
        Title = "Update department";

        isEditingMode = true;
        deptnoInput.IsEnabled = false;

        deptnoInput.Text = department.Deptno.ToString();
        dnameInput.Text = department.Dname.ToString();
        locInput.Text = department.Loc.ToString();

    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        var deptno = decimal.Parse(deptnoInput.Text);
        var dname = dnameInput.Text;
        var loc = locInput.Text;

        var department = new Department(deptno, dname, loc);

        bool isSuccess;

        if (isEditingMode)
        {
            isSuccess = _departmentManager.UpdateDepartment(department);

            if (isSuccess)
            {
                MessageBox.Show(
                    "Department was updated successfully",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
        else
        {
            isSuccess = _departmentManager.AddDepartment(department);

            if (isSuccess)
            {
                MessageBox.Show(
                    "Department was added successfully",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        if (isSuccess)
            Close();
    }
}
