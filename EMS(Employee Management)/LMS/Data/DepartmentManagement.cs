using LMS.Models;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Navigation;

namespace LMS.Data;

internal class DepartmentManagement
{
    private readonly EmployeeManagementDbContext _context;

    public DepartmentManagement()
    {
        _context = new EmployeeManagementDbContext();
    }

    public List<Department> GetDepartments() => _context.Departments.ToList();

    public bool AddDepartment(Department department)
    {
        _context.Departments.Add(department);
        var affectedRows = _context.SaveChanges();
        return affectedRows > 0;
    }

    public bool UpdateDepartment(Department department)
    {
        _context.Departments.Update(department);
        var affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool DeleteDepartment(decimal deptno)
    {
        var department = _context.Departments.FirstOrDefault(x => x.Number == deptno);

        if(department is null)
        {
            return false;
        }

        _context.Departments.Remove(department);
        var affectedRows = _context.SaveChanges();
        
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
