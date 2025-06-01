using System.ComponentModel.DataAnnotations;

namespace LMS.Models;

public class Department
{
    [Key]
    public decimal Number { get; set; }
    public string Name { get; set; }
    public string Location {  get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public Department()
    {
        Name = string.Empty;
        Location = string.Empty;
    }

    public Department(decimal deptno, string dname, string loc)
    {
        Number = deptno;
        Name = dname;
        Location = loc;
    }

    public override string ToString()
    {
        return $"{Name} ({Location})";
    }
}
