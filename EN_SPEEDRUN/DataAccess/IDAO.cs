using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess;
public interface IDAO<TDTO> : IDisposable where TDTO : class, IDTO {

    public TDTO GetById(int id);

    public TDTO GetSingleWhere(Func<TDTO, bool> predicate);

    public List<TDTO> GetAll();

    public List<TDTO> GetWhere(Func<TDTO, bool> predicate);

    public void LoadInContextById(IContext<TDTO> context, int id);

    public void LoadAllInContext(IContext<TDTO> context);

    public void Save(TDTO dto);

    public void Delete(TDTO dto);

}
