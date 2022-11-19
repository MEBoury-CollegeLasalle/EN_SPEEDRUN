using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess;
public interface IDTO {

    /// <summary>
    /// Returns the Id value of the <see cref="IDTO"/> instance.
    /// </summary>
    /// <returns>The Id of the <see cref="IDTO"/> instance.</returns>
    public int GetId();

}
