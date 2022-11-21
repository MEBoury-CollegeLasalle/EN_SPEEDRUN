using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class DoctorService : AbstractDtoService<DoctorDTO> {

    public DoctorService(IContext<DoctorDTO> dbContext) : base(new DoctorDAO(dbContext)) { }

    protected DoctorDAO GetDoctorDao() {
        return (DoctorDAO) this.daoInstance;
    }

    public List<DoctorDTO> GetClinicDoctors(int clinicId) {
        return this.GetDoctorDao().GetClinicDoctors(clinicId);
    }
}
