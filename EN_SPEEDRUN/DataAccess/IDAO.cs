using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess;
public interface IDAO<TDTO> : IDisposable where TDTO : class, IDTO {

    public TDTO GetById(int id);

    public void LoadInContextById(IContext<TDTO> context, int id);

    public List<TDTO> GetAll();

    public void LoadAllInContext(IContext<TDTO> context);

    public void Save(TDTO dto);

    public void Delete(TDTO dto);

}
