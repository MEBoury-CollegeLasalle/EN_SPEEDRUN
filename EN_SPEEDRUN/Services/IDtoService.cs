using EN_SPEEDRUN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public interface IDtoService<TDTO> : IService where TDTO : class, IDTO {

    public TDTO GetById(int id);

    public TDTO GetSingleWhere(Func<TDTO, bool> predicate);

    public List<TDTO> GetAll();

    public List<TDTO> GetWhere(Func<TDTO, bool> predicate);

    public void LoadDtoInContextById(IContext<TDTO> context, int id);

    public void LoadAllDtosInContext(IContext<TDTO> context);

}
