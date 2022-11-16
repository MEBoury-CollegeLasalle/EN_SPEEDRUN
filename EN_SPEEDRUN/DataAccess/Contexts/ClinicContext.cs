using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;

/// <summary>
/// 
/// </summary>
public class ClinicContext : DbContext {

    


    public DbSet<StatusDTO> Statuses { get; set; }
    public DbSet<AppointmentTimeDTO> AppointmentTimes { get; set; }
    public DbSet<AddressDTO> Addresses { get; set; }
    public DbSet<ClinicDTO> Clinics { get; set; }
    public DbSet<PatientDTO> Patients { get; set; }
    public DbSet<DoctorDTO> Doctors { get; set; }
    public DbSet<AppointmentDTO> Appointments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=.\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;TrustServerCertificate=true;");
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
                .Include(clinic => clinic.Address)
                .Include(clinic => clinic.ClinicDoctors)
                    .ThenInclude(clinicDocs => clinicDocs.Doctor)
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

    public List<AppointmentDTO> GetFilteredClinicAppointments(
            ClinicDTO clinic,
            string? patientNameSearch = null,
            DoctorDTO? doctorCriterion = null, 
            DateTime? afterDate = null,
            DateTime? beforeDate = null) {

        return this.Appointments
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .AsEnumerable()
            .Where(appointment => {

                // Clinic filter criterion
                if (appointment.Clinic.Id != clinic.Id) {
                    // appointment is not for this clinic: reject it
                    return false;
                }

                // patient name search criterion
                if (patientNameSearch is not null) {
                    if (appointment.Patient.FirstName.Contains(patientNameSearch) 
                    || appointment.Patient.LastName.Contains(patientNameSearch)) {
                        // patient name contains search criterion. OK
                    } else {
                        // criterion not null + name not contained: reject this appointment
                        return false;
                    }
                }

                // Doctor selection criterion
                if (doctorCriterion is not null && appointment.Doctor.Id != doctorCriterion.Id) {
                    // doctor criterion is set and doesnt match the appointment's doctor.
                    // reject this appointment
                    return false;
                }

                // After (or equal) appointment date criterion
                if (afterDate is not null && appointment.Date.Date < afterDate.Value.Date) {
                    // appointment is before the lower date limit criterion: reject appointment
                    return false;
                }

                // Before (or equal) appointment date criterion
                if (beforeDate is not null && appointment.Date.Date > beforeDate.Value.Date) {
                    // appointment is after the upper date limit criterion: reject appointment
                    return false;
                }

                // All filters checked: appointment valid for this criteria set.
                return true;
            })
            .ToList();

    }

    public AppointmentDTO GetAppointment(int id) {
        return this.Appointments
            .Where(appointment => appointment.Id == id)
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .Single();
    }

    public List<AppointmentDTO> GetPatientAppointments(PatientDTO patient) {
        return this.Appointments
            .Where(appointment => appointment.PatientId == patient.Id)
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .ToList();
    }

    public List<AppointmentDTO> GetDoctorAppointments(DoctorDTO doctor) {
        return this.Appointments
            .Where(appointment => appointment.DoctorId == doctor.Id)
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .ToList();
    }

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
