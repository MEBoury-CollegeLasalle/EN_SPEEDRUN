using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class AppointmentDAO : AbstractDAO<AppointmentDTO> {

    public AppointmentDAO(IContext<AppointmentDTO> context) : base(context) { }


    /// <summary>
    /// Auteur: Marc-Eric Boury
    /// </summary>
    /// <param name="clinic"></param>
    /// <param name="patientNameSearch"></param>
    /// <param name="doctorCriterion"></param>
    /// <param name="afterDate"></param>
    /// <param name="beforeDate"></param>
    /// <returns></returns>
    public List<AppointmentDTO> GetFilteredClinicAppointments(
            ClinicDTO clinic,
            string? patientNameSearch = null,
            DoctorDTO? doctorCriterion = null,
            DateTime? afterDate = null,
            DateTime? beforeDate = null) {

        return this.GetContext().GetDbSet()
            .Include(appointment => appointment.Clinic)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .Include(appointment => appointment.AppointmentTime)
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
                    // Doctor criterion is set and doesnt match the appointment's Doctor.
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
            .AsQueryable()
            .Include(appointment => appointment.AppointmentTime)
            .ToList();

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="patient"></param>
    /// <returns></returns>
    public List<AppointmentDTO> GetPatientAppointments(PatientDTO patient) {
        return this.GetContext().GetDbSet()
            .Where(appointment => appointment.PatientId == patient.Id)
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .ToList();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="doctor"></param>
    /// <returns></returns>
    public List<AppointmentDTO> GetDoctorAppointments(DoctorDTO doctor) {
        return this.GetContext().GetDbSet()
            .Where(appointment => appointment.DoctorId == doctor.Id)
            .Include(appointment => appointment.AppointmentTime)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .ToList();
    }

}
