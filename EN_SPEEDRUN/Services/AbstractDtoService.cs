using EN_SPEEDRUN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;

public abstract class AbstractDtoService<TDTO> : IDtoService<TDTO> where TDTO : class, IDTO {

    protected IDAO<TDTO> daoInstance;

    protected AbstractDtoService(IDAO<TDTO> daoInstance) {
        this.daoInstance = daoInstance;
    }

    public List<TDTO> GetAll() {
        return this.daoInstance.GetAll();
    }

    public TDTO GetById(int id) {
        return this.daoInstance.GetById(id);
    }

    public TDTO GetSingleWhere(Func<TDTO, bool> predicate) {
        return this.daoInstance.GetSingleWhere(predicate);
    }

    public List<TDTO> GetWhere(Func<TDTO, bool> predicate) {
        return this.daoInstance.GetWhere(predicate);
    }

    public void LoadAllDtosInContext(IContext<TDTO> context) {
        this.daoInstance.LoadAllInContext(context);
    }

    public void LoadDtoInContextById(IContext<TDTO> context, int id) {
        this.daoInstance.LoadInContextById(context, id);
    }

}
