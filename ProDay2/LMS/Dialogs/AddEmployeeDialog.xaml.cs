using LMS.Data;
using LMS.Models;
using System.Windows;

namespace LMS.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEmployeeDialog.xaml
    /// </summary>
    public partial class AddEmployeeDialog : Window
    {
        private readonly EmployeeManagement _databaseManager;
        private readonly bool isEditingMode;

        public AddEmployeeDialog()
        {
            InitializeComponent();
            
            hiredateInput.SelectedDate = DateTime.Now;
            _databaseManager = new EmployeeManagement();
        }

        public AddEmployeeDialog(Employee employee)
            : this()
        {
            isEditingMode = true;
            empnoInput.IsEnabled = false;

            empnoInput.Text = employee.Empno.ToString();
            enameInput.Text = employee.Ename.ToString();
            jobInput.Text = employee.Job.ToString();
            mgrInput.Text = employee.Mgr.ToString();
            hiredateInput.Text = employee.HireDate.ToString();
            salInput.Text = employee.Salary.ToString();
            commInput.Text = employee.Comm.ToString();
            deptnoInput.Text = employee.Deptno.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var empno = decimal.Parse(empnoInput.Text);
            var ename = enameInput.Text;
            var job = jobInput.Text;
            decimal? mgr = string.IsNullOrEmpty(mgrInput.Text) ? null : decimal.Parse(mgrInput.Text);
            var hiredate = hiredateInput.SelectedDate ?? DateTime.Now;
            var sal = decimal.Parse(salInput.Text);
            decimal? comm = string.IsNullOrEmpty(commInput.Text) ? null : decimal.Parse(commInput.Text);
            var deptno = decimal.Parse(deptnoInput.Text);

            var newEmployee = new Employee(empno, ename, job, mgr, hiredate, sal, comm, deptno);

            bool isSuccess;

            if (isEditingMode)
            {
                isSuccess = _databaseManager.UpdateEmployee( employee);
            }
            else
            {
                isSuccess = _databaseManager.Create(newEmployee);
            }

            if(isSuccess)
                Close();
        }
    }
}
