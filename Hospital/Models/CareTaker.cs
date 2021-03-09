using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("CARE_TAKERS")]
    public class CareTaker : Employee
    {
        [Column("SUPERVISOR_ID")]
        public int? SupervisorId { get; set; }
        public CareTaker Supervisor { get; set; }
    }
}