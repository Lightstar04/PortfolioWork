using LMS.Models;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace LMS.Data;

internal class DepartmentManagement
{
    public List<Department> GetDepartments()
    {
        SqlConnection connection = new SqlConnection("Data Source=PAVILION;Initial Catalog=employee_management;Integrated Security=True;Trust Server Certificate=True");
        List<Department> departments = new List<Department>();

        try
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM DEPT" +
                " ORDER BY DNAME, LOC";

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                decimal deptno = reader.GetDecimal(0);
                string dname = reader.GetString(1);
                string loc = reader.GetString(2);

                var department = new Department(deptno, dname, loc);
                departments.Add(department);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"There was an error while loading departments. Details: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            connection.Close();
        }

        return departments;
    }
}
