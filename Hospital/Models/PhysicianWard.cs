using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("PHYSICIAN_WARD_JT")]
    public class PhysicianWard
    {
        [Column("PHYSICIAN_ID", TypeName = "INT")]
        public int PhysicianId { get; set; }
        
        [Column("WARD_ID", TypeName = "INT")]
        public int WardId { get; set; }
        
        [Required]
        public Physician Physician { get; set; }
        
        [Required]
        public Ward Ward { get; set; }
        
        [Required]
        [Column("WORKING_HOURS", TypeName = "INT")]
        public int WorkingHours { get; set; }
    }
}