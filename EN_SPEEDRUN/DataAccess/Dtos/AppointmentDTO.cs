using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Appointments")]
public class AppointmentDTO : IDto {

    [Key]
    public int Id { get; private set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public int ClinicId { get; set; }

    [Required]
    public int AppointmentTimeId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; private set; }


    // Navigation properties

    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }

    [ForeignKey("PatientId")]
    public PatientDTO Patient { get; set; }

    [ForeignKey("DoctorId")]
    public DoctorDTO Doctor { get; set; }

    [ForeignKey("ClinicId")]
    public ClinicDTO Clinic { get; set; }

    [ForeignKey("AppointmentTimeId")]
    public AppointmentTimeDTO AppointmentTime { get; set; }
}
