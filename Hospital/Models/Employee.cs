using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EMPLOYEE_ID", TypeName = "INT")]
        public int EmployeeId { get; set; }
        
        [Required]
        [Column("SVNR", TypeName = "INT")]
        public int SVNR { get; set; }

        [Required]
        [Column("FIRST_NAME", TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }
        
        [Required]
        [Column("LAST_NAME", TypeName = "VARCHAR(30)")]
        public string LastName { get; set; }

        [Required]
        [Column("SALARY", TypeName = "INT")]
        public int Salary { get; set; }
    }
}