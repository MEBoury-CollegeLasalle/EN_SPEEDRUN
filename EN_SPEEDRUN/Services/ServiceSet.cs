using EN_SPEEDRUN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public class ServiceSet : Dictionary<Type, IService> {

    public ServiceSet() : base() { }

    public AbstractDtoService<TDTO> GetDtoService<TDTO>() where TDTO : class, IDTO {
        return (AbstractDtoService<TDTO>) this[typeof(TDTO)];
    }
}
