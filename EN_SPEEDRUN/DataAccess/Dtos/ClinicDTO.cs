using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Clinics")]
public class ClinicDTO : IDto {

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int AddressId { get; set; }

    // TODO: Modelize opening hours



    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("AddressId")]
    public AddressDTO Address { get; set; }

    public List<DoctorDTO> Doctors { get; set; }

    public List<AppointmentDTO> Appointments { get; set; }
}
