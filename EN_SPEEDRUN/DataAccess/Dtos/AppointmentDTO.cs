using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Appointments")]
public class AppointmentDTO : IDTO {

    #region Properties

    [Key]
    public int Id { get; private set; }

    [Required]
    public int StatusId { get; set; }

    [Column("Date", TypeName = "date")]
    [Required]
    public DateTime Date { get; set; }

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

    #endregion


    public AppointmentDTO(
        DateTime date, 
        StatusDTO status, 
        PatientDTO patient, 
        DoctorDTO doctor, 
        ClinicDTO clinic, 
        AppointmentTimeDTO appointmentTime
        ) {

        this.Date = date;
        this.Status = status;
        this.StatusId = status.GetId();
        this.Patient = patient;
        this.PatientId = patient.GetId();
        this.Doctor = doctor;
        this.DoctorId = doctor.GetId();
        this.Clinic = clinic;
        this.ClinicId = clinic.GetId();
        this.AppointmentTime = appointmentTime;
        this.AppointmentTimeId = appointmentTime.GetId();
    }




    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }
}
