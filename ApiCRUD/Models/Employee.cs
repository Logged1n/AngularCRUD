using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCRUD.Models;

[Table("Employee")]
public class Employee
{
    [Key]
    public int? id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string dob { get; set; }
    public string gender { get; set; }
    public string education { get; set; }
    public string company { get; set; }
    public int experience { get; set; }
    public int salary { get; set; }
    public string photoSVG { get; set; }
}