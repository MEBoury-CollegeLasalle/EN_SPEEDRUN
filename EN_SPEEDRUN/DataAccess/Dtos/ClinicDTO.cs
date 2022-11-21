using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Net;
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



    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("AddressId")]
    public AddressDTO Address { get; set; } = null!;


    public virtual List<ClinicDoctorDTO> ClinicDoctors { get; set; } = null!;

    public virtual List<AppointmentDTO> Appointments { get; set; } = null!;

    public virtual List<UserDTO> Users { get; set; } = null!;



    public ClinicDTO(string name, int addressId) {
        this.Name = name;
        this.AddressId = addressId;
    }

    public ClinicDTO(
        string name, 
        AddressDTO address, 
        List<ClinicDoctorDTO>? clinicDoctorsList = null, 
        List<AppointmentDTO>? appointmentsList = null,
        List<UserDTO>? users = null
        ) {

        this.Name = name;
        this.Address = address;
        this.AddressId = address.GetId();
        this.ClinicDoctors = clinicDoctorsList ?? new List<ClinicDoctorDTO>();
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
        Debug.WriteLine("#### DOCS ####");
        foreach (DoctorDTO doc in doctors) {
            Debug.WriteLine(doc.DisplayName);
        }
        return doctors;
    }
}
