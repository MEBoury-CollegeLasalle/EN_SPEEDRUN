using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class StatusService : AbstractDtoService<StatusDTO> {
    public StatusService(IContext<StatusDTO> dbContext) : base(new StatusDAO(dbContext)) { }

    protected StatusDAO GetStatusDao() {
        return (StatusDAO) this.daoInstance;
    }

    public StatusDTO GetActiveStatus() {
        return this.daoInstance.GetSingleWhere(status => status.StatusCode == StatusDTO.Statuses.ACTIVE);
    }
}
