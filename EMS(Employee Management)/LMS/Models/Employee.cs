using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models;

public class Employee
{
    [Key]
    public decimal Number { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public decimal? Commission {  get; set; }

    [ForeignKey(nameof(DepartmentNumber))]
    public virtual Department Department { get; set; }
    public decimal DepartmentNumber {  get; set; }

    [ForeignKey(nameof(ManagerNumber))]
    public virtual Employee? Manager {  get; set; }
    public decimal? ManagerNumber { get; set; }

    public Employee() { }

    public Employee(
        decimal empno, string ename, 
        string job, decimal? mgr, 
        DateTime hireDate, decimal salary, 
        decimal? comm, decimal deptno)
    {
        Number = empno;
        Name = ename;
        Job = job;
        ManagerNumber = mgr;
        HireDate = hireDate;
        Salary = salary;
        Commission = comm;
        DepartmentNumber = deptno;
    }

    public override string ToString()
    {
        return $"{Name} ({Number})";
    }
}
