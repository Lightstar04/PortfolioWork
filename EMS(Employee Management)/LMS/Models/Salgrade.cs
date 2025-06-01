using System.ComponentModel.DataAnnotations;

namespace LMS.Models;

public class Salgrade
{
    [Key]
    public int Grade {  get; set; }
    public decimal LowSalary {  get; set; }
    public decimal HighSalary {  get; set; }
}
