using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Pivots;

[Table("ClinicDoctors")]
[Index("DoctorId", "ClinicId", IsUnique = true, Name = "UNIQ_ClinicDoctors_ClinicId_DoctorId")]
public class ClinicDoctor : IPivot {

    [Key]
    public int Id { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public int ClinicId { get; set; }

    // Navigation properties

    [ForeignKey("DoctorId")]
    public DoctorDTO Doctor { get; set; }

    [ForeignKey("ClinicId")]
    public ClinicDTO Clinic { get; set; }
}
