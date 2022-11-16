using EN_SPEEDRUN.DataAccess.Interfaces;
using EN_SPEEDRUN.DataAccess.Pivots;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Doctors")]
public class DoctorDTO : IDto {

    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    [StringLength(48)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(48)]
    public string LastName { get; set; }

    [Required]
    [StringLength(32)]
    public string LicenseNo { get; set; }

    [Required]
    public DateTime DateHired { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }



    // Navigation Properties

    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }

    [ForeignKey("ClinicId")]
    public List<ClinicDoctor> ClinicDoctors { get; set; }

    public List<AppointmentDTO> Appointments { get; set; }


}
