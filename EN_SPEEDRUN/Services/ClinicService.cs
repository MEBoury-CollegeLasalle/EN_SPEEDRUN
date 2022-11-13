using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public class ClinicService : IService {

    private static ClinicService INSTANCE;

    private ClinicService() { }

    public static ClinicService GetInstance() {
        if (INSTANCE is null) {
            INSTANCE = new ClinicService();
        }
        return INSTANCE;
    }


    public ClinicDTO LoadClinicForUser(UserDTO user) {
        using (ClinicContext context = new ClinicContext()) {
            return context.GetClinicForAppUser(user);
        }
    }

}
