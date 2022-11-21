using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("ClinicDoctors")]
[Index("DoctorId", "ClinicId", IsUnique = true, Name = "UNIQ_ClinicDoctors_ClinicId_DoctorId")]
public class ClinicDoctorDTO : IPivot, IDTO {

    [Key]
    public int Id { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public int ClinicId { get; set; }

    // Navigation properties

    [ForeignKey("DoctorId")]
    public DoctorDTO Doctor { get; set; } = null!;

    [ForeignKey("ClinicId")]
    public ClinicDTO Clinic { get; set; } = null!;


    public ClinicDoctorDTO(int doctorId, int clinicId) {
        this.DoctorId = doctorId;
        this.ClinicId = clinicId;
    }


    public int GetId() {
        return this.Id;
    }
}
