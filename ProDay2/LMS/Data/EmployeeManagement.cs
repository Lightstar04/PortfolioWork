
using LMS.Models;
using Microsoft.Data.SqlClient;
using System.CodeDom;
using System.Windows;

namespace LMS.Data
{
    class EmployeeManagement
    {
        public List<Employee> GetEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=PAVILION;Initial Catalog=employee_management;Integrated Security=True;Trust Server Certificate=True");
            List<Employee> employees = new List<Employee>();
            
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new()
                {
                    CommandText = "SELECT * FROM EMP",
                    Connection = sqlConnection
                };

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    decimal empno = reader.GetDecimal(0);
                    string ename = reader.GetString(1);
                    string job = reader.GetString(2);
                    decimal? mgr = reader.IsDBNull(3) ? null : reader.GetDecimal(3);
                    DateTime hireDate = reader.GetDateTime(4);
                    decimal salary = reader.GetDecimal(5);
                    decimal? commission = reader.IsDBNull(6) ? null : reader.GetDecimal(6);
                    decimal deptno = reader.GetDecimal(7);
                    
                    var employee = new Employee(empno, ename, job, mgr, hireDate, salary, commission, deptno);

                    employees.Add(employee);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show($"There was an error while loading data from database {e.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }

            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection("Data Source=PAVILION;Initial Catalog=employee_management;Integrated Security=True;Trust Server Certificate=True");

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO EMP(Empno, Ename, Job, Mgr, Hiredate, Sal, Comm, Deptno) " +
                    $"VALUES(@empno, @ename, @job, @mgr, @hiredate, @salary, @commission, @deptno)";

                command.Parameters.AddWithValue("@empno", employee.Empno);
                command.Parameters.AddWithValue("@ename", employee.Ename);
                command.Parameters.AddWithValue("@job", employee.Job);
                command.Parameters.AddWithValue("@mgr", employee.Mgr == null ? DBNull.Value : employee.Mgr);
                command.Parameters.AddWithValue("@hiredate", employee.HireDate.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@commission", employee.Comm == null ? DBNull.Value : employee.Comm);
                command.Parameters.AddWithValue("@deptno", employee.Deptno);

                var affectedRows = command.ExecuteNonQuery();

                if(affectedRows > 0)
                {
                    MessageBox.Show(
                        $"{employee.Ename} was successfully created",
                        "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    return true;
                }

                MessageBox.Show(
                    $"There was an error while saving new employee",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }
            catch(Exception e)
            {
                MessageBox.Show(
                    $"There was an error while saving new employee: {e.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection("Data Source=PAVILION;Initial Catalog=employee_management;Integrated Security=True;Trust Server Certificate=True");

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"UPDATE EMP SET" +
                    $" Ename = @ename, Job = @job, " +
                    $"Mgr = @mgr, Hiredate = @hiredate, " +
                    $"Sal = @salary, Comm = @commission, Deptno = @deptno" +
                    $" WHERE Empno = @empno";

                command.Parameters.AddWithValue("@empno", employee.Empno);
                command.Parameters.AddWithValue("@ename", employee.Ename);
                command.Parameters.AddWithValue("@job", employee.Job);
                command.Parameters.AddWithValue("@mgr", employee.Mgr == null ? DBNull.Value : employee.Mgr);
                command.Parameters.AddWithValue("@hiredate", employee.HireDate.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@salary", employee.Salary);
                command.Parameters.AddWithValue("@commission", employee.Comm == null ? DBNull.Value : employee.Comm);
                command.Parameters.AddWithValue("@deptno", employee.Deptno);

                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"There was an error while updating employee: {employee.Ename}. Details: {e.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return affectedRows > 0;
        }

        public bool DeleteEmployee(decimal empno)
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection("Data Source=PAVILION;Initial Catalog=employee_management;Integrated Security=True;Trust Server Certificate=True");

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM EMP WHERE Empno = @empno";

                command.Parameters.AddWithValue("@empno", empno);

                affectedRows = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(
                    $"There was an error while deleting employee. Details: {e.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

            return affectedRows > 0;
        }
    }
}
