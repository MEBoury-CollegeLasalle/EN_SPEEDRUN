using EN_SPEEDRUN.DataAccess.Pivots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Doctors")]
public class DoctorDTO : IDTO {

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



    public DoctorDTO(int statusId, string firstName, string lastName, string licenseNo, DateTime dateHired) {

        this.FirstName = firstName;
        this.LastName = lastName;
        this.LicenseNo = licenseNo;
        this.StatusId = statusId;
        this.DateHired = dateHired;
    }

    public DoctorDTO(
        string firstName, 
        string lastName, 
        string licenseNo,
        StatusDTO status,
        DateTime dateHired, 
        List<ClinicDoctor>? clinicDoctors = null, 
        List<AppointmentDTO>? appointments = null) {

        this.FirstName = firstName;
        this.LastName = lastName;
        this.LicenseNo = licenseNo;
        this.Status = status;
        this.StatusId = status.GetId();
        this.DateHired = dateHired;
        this.ClinicDoctors = clinicDoctors ?? new List<ClinicDoctor>();
        this.Appointments = appointments ?? new List<AppointmentDTO>();
    }




    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }

}
