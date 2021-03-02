using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("PHYSICIANS")]
    public class Physician : Employee
    {
        [Required]
        [Column("JOB_SPECIALISATION", TypeName = "VARCHAR(30)")]
        public EJobSpecialisation JobSpecialisation { get; set; }
    }
}