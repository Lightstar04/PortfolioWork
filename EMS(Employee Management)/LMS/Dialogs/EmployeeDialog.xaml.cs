﻿using LMS.Data;
using LMS.Models;
using System.Windows;

namespace LMS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEmployeeDialog.xaml
    /// </summary>
    public partial class EmployeeDialog : Window
    {
        private readonly EmployeeManagement _databaseManager;
        private readonly DepartmentManagement _departmentManager;
        private readonly bool isEditingMode;

        public EmployeeDialog()
        {
            InitializeComponent();
            
            Title = "Add Employee";
            
            _databaseManager = new EmployeeManagement();
            _departmentManager = new DepartmentManagement();
            
            hiredateInput.SelectedDate = DateTime.Now;

            var departments = _departmentManager.GetDepartments();
            departmentsComboBox.ItemsSource = departments;
            departmentsComboBox.SelectedIndex = 0;

            var managers = _databaseManager.GetEmployees();
            mgrComboBox.ItemsSource = managers;
            mgrComboBox.SelectedIndex = 0;

        }

        public EmployeeDialog(Employee employee)
            : this()
        {
            Title = "Update Employee";

            isEditingMode = true;
            empnoInput.IsEnabled = false;

            PopulateData(employee);
        }

        private void PopulateData(Employee employee)
        {
            empnoInput.Text = employee.Number.ToString();
            enameInput.Text = employee.Name.ToString();
            jobInput.Text = employee.Job.ToString();
            hiredateInput.SelectedDate = employee.HireDate;
            salInput.Text = employee.Salary.ToString();
            commInput.Text = employee.Commission.ToString();

            var departments = departmentsComboBox.ItemsSource as List<Department>;
            if (departments == null)
            {
                return;
            }

            var department = departments.Find(x => x.Number == employee.DepartmentNumber);
            departmentsComboBox.SelectedItem = department;

            var managers = mgrComboBox.ItemsSource as List<Employee>;
            if (managers == null)
            {
                return;
            }

            var mgr = managers.Find(x => x.Number == employee.ManagerNumber);
            mgrComboBox.SelectedItem = mgr;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var empno = decimal.Parse(empnoInput.Text);
            var ename = enameInput.Text;
            var job = jobInput.Text;
            var hiredate = hiredateInput.SelectedDate ?? DateTime.Now;
            var sal = decimal.Parse(salInput.Text);
            decimal? comm = string.IsNullOrEmpty(commInput.Text) ? null : decimal.Parse(commInput.Text);

            var selectedDepartment = departmentsComboBox.SelectedItem as Department;
            if(selectedDepartment is null)
            {
                MessageBox.Show(
                    "Please, select department",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var selectedManager = mgrComboBox.SelectedItem as Employee;

            var mgr = selectedManager?.Number;
            var deptno = selectedDepartment.Number;

            var employee = new Employee(empno, ename, job, mgr, hiredate, sal, comm, deptno);

            bool isSuccess;

            if (isEditingMode)
            {
                isSuccess = _databaseManager.UpdateEmployee(employee);

                if(isSuccess)
                {
                    MessageBox.Show(
                        "Employee was updated successfully",
                        "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            else
            {
                isSuccess = _databaseManager.AddEmployee(employee);

                MessageBox.Show(
                        "Employee was added successfully",
                        "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }

            if(isSuccess)
                Close();
        }
    }
}
