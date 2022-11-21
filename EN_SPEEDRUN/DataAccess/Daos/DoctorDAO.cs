using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class DoctorDAO : AbstractDAO<DoctorDTO> {

    public DoctorDAO(IContext<DoctorDTO> context) : base(context) { }

    public List<DoctorDTO> GetClinicDoctors(int clinicId) {
        return this.GetContext().GetDbSet()
            .Include(doctor => doctor.ClinicDoctors)
            .Where(doctor => doctor.ClinicDoctors.Any(clinDoctor => clinDoctor.ClinicId == clinicId))
            .ToList();
    }

}
