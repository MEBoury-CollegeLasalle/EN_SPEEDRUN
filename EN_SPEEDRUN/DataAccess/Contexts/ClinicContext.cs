using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;
public class ClinicContext : DbContext {

    


    public DbSet<StatusDTO> Statuses { get; set; }
    public DbSet<AppointmentTimeDTO> AppointmentTimes { get; set; }
    public DbSet<AddressDTO> Addresses { get; set; }
    public DbSet<ClinicDTO> Clinics { get; set; }
    public DbSet<PatientDTO> Patients { get; set; }
    public DbSet<DoctorDTO> Doctors { get; set; }
    public DbSet<AppointmentDTO> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=.\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;");
    }


    #region Clinic-related methods

    /// <summary>
    /// Retrieves the associated clinic object for a passed user.
    /// 
    /// Eager loads:
    /// <list type="bullet">
    /// <item>Clinic's doctors and the doctor's status</item>
    /// <item>Clinic's appointments and the appointments' statuses and times</item>
    /// </list>
    /// </summary>
    /// <param name="user"></param>
    /// <returns>The clinic object associated with the user</returns>
    /// <exception cref="InvalidNullArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public ClinicDTO GetClinicForAppUser(UserDTO user) {
        if (user is null) {
            throw new InvalidNullArgumentException(
                "Null user passed.",
                nameof(user),
                this.GetType().FullName + "GetClinicForAppUser"
                );
        }
        try {
            ClinicDTO clinic = this.Clinics
                .Where(clinic => clinic.Id == user.ClinicId)
                .Include(clinic => clinic.ClinicDoctors)
                    .ThenInclude(clinicDoctor => clinicDoctor.Doctor)
                        .ThenInclude(doctor => doctor.Status)
                .Include(clinic => clinic.Appointments)
                    .ThenInclude(appointment => appointment.Status)
                .Include(clinic => clinic.Appointments)
                    .ThenInclude(appointment => appointment.AppointmentTime)
                .Single();
            return clinic;
        } catch (Exception ex) {
            throw new Exception("User clinic nor found.", ex);
        }
    }

    #endregion


    #region Patient-related methods

    /// <summary>
    /// Saves a passed patient object in the database
    /// </summary>
    /// <param name="patient"></param>
    public void SaveNewPatient(PatientDTO patient) {
        this.Patients.Add(patient);
        this.SaveChanges();
    }

    #endregion


    #region Appointment-related methods

    /// <summary>
    /// Saves a passed appointment object in the database
    /// </summary>
    /// <param name="appointment"></param>
    public void SaveNewAppointment(AppointmentDTO appointment) {
        this.Appointments.Add(appointment);
        this.SaveChanges();
    }

    #endregion
}
