
using LMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace LMS.Data;

class EmployeeManagement
{
    private readonly EmployeeManagementDbContext _context;

    public EmployeeManagement()
    {
        _context = new EmployeeManagementDbContext();
    }

    // Eager loading

    public List<Employee> GetEmployees()
    {
        var employees = _context.Employees
            .Include(e => e.Department)
            .Include(d => d.Manager)
            .ToList();

        return employees;
    }

    // Lazy loading

    //public List<Employee> GetEmployeesLazy()
    //{
    //    var employees = _context.Employees.ToList();
    //    foreach (var employee in employees)
    //    {
    //        MessageBox.Show(employee.Name);  // Loads only employee's properties
    //        MessageBox.Show(employee.Department.Name);  // Loads only employee and department's properties
    //        MessageBox.Show(employee.Department.City.Name); // Loads only city properties
    //        MessageBox.Show(employee.Department.City.Country.Name) // Loads only country's properties
    //    }

    //    return employees;
    //}

    public bool AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        var affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        var affectedRows = _context.SaveChanges();
        
        return affectedRows > 0;
    }

    public bool DeleteEmployee(decimal empno)
    {
        var employee = _context.Employees.FirstOrDefault(x => x.Number == empno);

        if(employee is null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        var affectedRows = _context.SaveChanges();

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
