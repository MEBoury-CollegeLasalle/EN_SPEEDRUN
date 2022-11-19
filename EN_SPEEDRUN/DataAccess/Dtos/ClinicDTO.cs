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
public class ClinicDTO : IDTO {

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

    public List<UserDTO> Users { get; set; }



    public ClinicDTO(
        string name, 
        AddressDTO address, 
        List<ClinicDoctor>? clinicDoctorsList = null, 
        List<AppointmentDTO>? appointmentsList = null,
        List<UserDTO>? users = null
        ) {

        this.Name = name;
        this.Address = address;
        this.AddressId = address.GetId();
        this.ClinicDoctors = clinicDoctorsList ?? new List<ClinicDoctor>();
        this.Appointments = appointmentsList ?? new List<AppointmentDTO>();
        this.Users = users ?? new List<UserDTO>();

    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }

    public List<DoctorDTO> GetDoctors() {
        List<DoctorDTO> doctors = new List<DoctorDTO>();
        this.ClinicDoctors.ForEach(x => doctors.Add(x.Doctor));
        return doctors;
    }
}
