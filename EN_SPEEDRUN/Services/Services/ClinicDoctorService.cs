using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class ClinicDoctorService : AbstractDtoService<ClinicDoctorDTO> {
    public ClinicDoctorService(IContext<ClinicDoctorDTO> dbContext) : base(new ClinicDoctorDAO(dbContext)) { }

    protected ClinicDoctorDAO GetClinicDoctorDao() {
        return (ClinicDoctorDAO) this.daoInstance;
    }
}
