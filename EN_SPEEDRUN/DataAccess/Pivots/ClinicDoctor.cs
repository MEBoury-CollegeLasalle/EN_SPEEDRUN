using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Pivots;
public class ClinicDoctor : IPivot {

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
