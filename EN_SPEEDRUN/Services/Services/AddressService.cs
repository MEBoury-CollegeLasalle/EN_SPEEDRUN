using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class AddressService : AbstractDtoService<AddressDTO> {

    public AddressService(IContext<AddressDTO> dbContext) : base(new AddressDAO(dbContext)) { }

    protected AddressDAO GetAddressDao() {
        return (AddressDAO) this.daoInstance;
    }
}
