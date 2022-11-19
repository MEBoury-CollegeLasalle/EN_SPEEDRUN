using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess;
public interface IContext<TDTO> : IDisposable where TDTO : class, IDTO {

    public DbSet<TDTO> GetDbSet();

    public int SaveChanges();

}
