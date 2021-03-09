using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("WARDS")]
    public class Ward
    {
        [Required]
        [ForeignKey("HOSPITAL_FACILITY_ID")]
        public HospitalFacility HospitalFacility { get; set; }
        
        [Key]
        [Column("WARD_ID", TypeName = "INT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WardId { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("CARRYING_CAPACITY", TypeName = "INT")]
        public int CarryingCapacity { get; set; }
        
        public Physician LeadPhysician { get; set; }
        
        [Column("PHYSICIAN_ID")]
        public int? LeadPhysicianId { get; set; }
    }
}