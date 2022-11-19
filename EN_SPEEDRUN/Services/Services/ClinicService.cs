using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class ClinicService : IService {

    private ClinicDAO clinicDao;

    public ClinicService(IContext<ClinicDTO> context) { 
        this.clinicDao = new ClinicDAO(context);
    }

    public ClinicDTO LoadClinicForUser(UserDTO user) {
        return this.clinicDao.GetUserClinic(user);
    }

}
