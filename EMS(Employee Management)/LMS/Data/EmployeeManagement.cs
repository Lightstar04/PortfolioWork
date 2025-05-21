
using LMS.Models;
using Microsoft.Data.SqlClient;

namespace LMS.Data
{
    class EmployeeManagement
    {
        private readonly DatabaseService _databaseService;

        public EmployeeManagement()
        {
            _databaseService = new DatabaseService();
        }

        public List<Employee> GetEmployees()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "SELECT * FROM EMP";

            var employees = _databaseService.ExecuteReader(command, DataConverter);

            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            SqlCommand command = new SqlCommand();
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

            var affectedRows = _databaseService.ExecuteNonQuery(command);

            return affectedRows > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            SqlCommand command = new SqlCommand();
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

            var affectedRows = _databaseService.ExecuteNonQuery(command);
            
            return affectedRows > 0;
        }

        public bool DeleteEmployee(decimal empno)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"DELETE FROM EMP WHERE Empno = @empno";

            command.Parameters.AddWithValue("@empno", empno);

            var affectedRows = _databaseService.ExecuteNonQuery(command);

            return affectedRows > 0;
        }

        public List<Employee> DataConverter(SqlDataReader reader)
        {
            List<Employee> employees = new List<Employee>();

            while (reader.Read())
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

            return employees;
        }
    }
}
