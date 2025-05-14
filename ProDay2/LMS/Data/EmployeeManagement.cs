
using LMS.Models;
using Microsoft.Data.SqlClient;
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
    }
}
