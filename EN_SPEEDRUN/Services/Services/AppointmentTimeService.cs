using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class AppointmentTimeService : AbstractDtoService<AppointmentTimeDTO> {
    public AppointmentTimeService(IContext<AppointmentTimeDTO> dbContext) : base(new AppointmentTimeDAO(dbContext)) {}

    protected AppointmentTimeDAO GetAppointmentTimeDao() {
        return (AppointmentTimeDAO) this.daoInstance;
    }
}
