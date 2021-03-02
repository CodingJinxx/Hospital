using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    [Table("HOSPITAL_FACILITIES")]
    public class HospitalFacility
    {
        [Key]
        [Column("FACILITY_ID", TypeName = "INT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }

        [Required]
        [Column("NAME", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Required]
        [Column("PHONE_NR", TypeName = "VARCHAR(20)")]
        public string PhoneNumber { get; set; }
    }
}