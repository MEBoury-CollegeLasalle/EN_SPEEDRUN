using EN_SPEEDRUN.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class AppointmentTimeDAO : AbstractDAO<AppointmentTimeDTO> {

    public AppointmentTimeDAO(IContext<AppointmentTimeDTO> context) : base(context) { }

}
