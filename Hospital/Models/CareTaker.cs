using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("CARE_TAKERS")]
    public class CareTaker : Employee
    {
        [ForeignKey("SUPERVISOR_ID")]
        public CareTaker Supervisor { get; set; }
    }
}