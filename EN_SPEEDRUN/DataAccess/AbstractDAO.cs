using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess;
public abstract class AbstractDAO<TDTO> : IDAO<TDTO> where TDTO : class, IDTO {

    protected IContext<TDTO> context;

    protected AbstractDAO(IContext<TDTO> context) {
        // TODO: finish exception message
        this.context = context ?? throw new InvalidNullArgumentException("whatever...", "context", "AbstractDAO");
    }

    public void Delete(TDTO dto) {
        this.context.GetDbSet().Remove(dto);
        this.context.SaveChanges();
    }

    public void Dispose() {
        this.context.Dispose();
    }

    public IContext<TDTO> GetContext() {
        return this.context;
    }

    public List<TDTO> GetAll() {
        return this.context.GetDbSet().ToList();
    }

    public TDTO GetById(int id) {
        return this.context.GetDbSet().AsEnumerable().Where(dto => dto.GetId() == id).Single();
    }

    public void LoadAllInContext(IContext<TDTO> context) {
        // TODO: check for null context
        _ = context.GetDbSet().ToList();
    }

    public void LoadInContextById(IContext<TDTO> context, int id) {
        // TODO: check for null context
        _ = context.GetDbSet().Where(dto => dto.GetId() == id).Single();
    }

    public void Save(TDTO dto) {
        this.context.GetDbSet().Add(dto);
        this.context.SaveChanges();
    }

    public List<TDTO> GetWhere(Func<TDTO, bool> predicate) {
        return this.context.GetDbSet().Where(predicate).ToList();
    }

    public TDTO GetSingleWhere(Func<TDTO, bool> predicate) {
        return this.context.GetDbSet().Where(predicate).Single();
    }
}
