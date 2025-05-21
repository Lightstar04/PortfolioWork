using LMS.Models;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace LMS.Data;

internal class DepartmentManagement
{
    private readonly DatabaseService _databaseService;

    public DepartmentManagement()
    {
        _databaseService = new DatabaseService();
    }

    public List<Department> GetDepartments()
    {
        SqlCommand command = new SqlCommand();

        command.CommandText = "SELECT * FROM DEPT";

        var departments = _databaseService.ExecuteReader(command, DataConverter);

        return departments;

    }

    public bool AddDepartment(Department department)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = $"INSERT INTO DEPT(Deptno, Dname, Loc)" +
            $"VALUES(@deptno, @dname, @loc)";

        command.Parameters.AddWithValue("@deptno", department.Deptno);
        command.Parameters.AddWithValue("@dname", department.Dname);
        command.Parameters.AddWithValue("@loc", department.Loc);

        var affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool UpdateDepartment(Department department)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = $"UPDATE DEPT SET" +
            $" Dname = @dname, Loc = @loc" +
            $" WHERE Deptno = @deptno";

        command.Parameters.AddWithValue("@deptno", department.Deptno);
        command.Parameters.AddWithValue("@dname", department.Dname);
        command.Parameters.AddWithValue("@loc", department.Loc);

        var affectedRows = _databaseService.ExecuteNonQuery(command);

        return affectedRows > 0;
    }

    public bool DeleteDepartment(decimal deptno)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = "DELETE FROM DEPT WHERE Deptno = @deptno";

        command.Parameters.AddWithValue("@deptno", deptno);

        var affectedRows = _databaseService.ExecuteNonQuery(command);
        
        return affectedRows > 0;
    }

    public List<Department> DataConverter(SqlDataReader reader)
    {
        List<Department> departments = new List<Department>();

        while (reader.Read())
        {
            decimal deptno = reader.GetDecimal(0);
            string dname = reader.GetString(1);
            string loc = reader.GetString(2);

            var department = new Department(deptno, dname, loc);
            departments.Add(department);
        }

        return departments;
    }
}
