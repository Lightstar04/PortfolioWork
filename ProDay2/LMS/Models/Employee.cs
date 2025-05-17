namespace LMS.Models;

public class Employee
{
    public decimal Empno { get; set; }
    public string Ename { get; set; }
    public string Job { get; set; }
    public decimal? Mgr { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public decimal? Comm {  get; set; }
    public decimal Deptno {  get; set; }

    public Employee() { }

    public Employee(
        decimal empno, string ename, 
        string job, decimal? mgr, 
        DateTime hireDate, decimal salary, 
        decimal? comm, decimal deptno)
    {
        Empno = empno;
        Ename = ename;
        Job = job;
        Mgr = mgr;
        HireDate = hireDate;
        Salary = salary;
        Comm = comm;
        Deptno = deptno;
    }

    public override string ToString()
    {
        return $"{Ename} ({Empno})";
    }
}
