using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Patients")]
public class PatientDTO : IDto {

    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    [StringLength(64)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(64)]
    public string LastName { get; set; }

    [Required]
    [StringLength(32)]
    public string HealthCardNumber { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }


    public List<AppointmentDTO> Appointments { get; set; }
}
