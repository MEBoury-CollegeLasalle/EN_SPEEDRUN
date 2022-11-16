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

[Table("Clinics")]
public class ClinicDTO : IDto {

    [Key]
    public int Id { get; private set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public int AddressId { get; set; }

    // TODO: Modelize opening hours



    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("AddressId")]
    public AddressDTO Address { get; set; }


    [ForeignKey("DoctorId")]
    public List<ClinicDoctor> ClinicDoctors { get; set; }

    public List<AppointmentDTO> Appointments { get; set; }





    public List<DoctorDTO> GetDoctors() {
        List<DoctorDTO> doctors = new List<DoctorDTO>();
        this.ClinicDoctors.ForEach(x => doctors.Add(x.Doctor));
        return doctors;
    }
}
