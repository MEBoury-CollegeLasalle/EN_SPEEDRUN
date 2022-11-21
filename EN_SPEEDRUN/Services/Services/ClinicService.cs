using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class ClinicService : AbstractDtoService<ClinicDTO> {

    private readonly ClinicDTO loadedClinic;

    public ClinicService(IContext<ClinicDTO> context) : base(new ClinicDAO(context)) {
        this.loadedClinic = this.GetClinicDao().GetUserClinic(MainService.GetInstance().GetLoginService().RequireLoggedInUser());
    }

    public ClinicDTO GetLoadedClinic() {
        return this.loadedClinic;
    }

    protected ClinicDAO GetClinicDao() {
        return (ClinicDAO) this.daoInstance;
    }

}
