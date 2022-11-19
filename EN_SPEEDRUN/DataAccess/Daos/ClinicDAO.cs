using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class ClinicDAO : AbstractDAO<ClinicDTO> {

    public ClinicDAO(IContext<ClinicDTO> context) : base(context) { }

    
    public ClinicDTO GetUserClinic(UserDTO user) {

        return this.GetContext().GetDbSet()
            .Where(clinic => clinic.Id == user.ClinicId)
            .Include(clinic => clinic.Address)
            .Include(clinic => clinic.ClinicDoctors)
                .ThenInclude(clinicDoctor => clinicDoctor.Doctor)
            .Include(clinic => clinic.Appointments)
                .ThenInclude(appointment => appointment.Patient)
            .Include(clinic => clinic.Appointments)
                .ThenInclude(appointment => appointment.AppointmentTime)
            .Single();
    }
}
