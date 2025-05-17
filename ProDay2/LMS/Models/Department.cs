namespace LMS.Models;

class Department
{
    public decimal Deptno { get; set; }
    public string Dname { get; set; }
    public string Loc {  get; set; }

    public Department()
    {
        Dname = string.Empty;
        Loc = string.Empty;
    }

    public Department(decimal deptno, string dname, string loc)
    {
        Deptno = deptno;
        Dname = dname;
        Loc = loc;
    }

    public override string ToString()
    {
        return $"{Dname} ({Loc})";
    }
}
