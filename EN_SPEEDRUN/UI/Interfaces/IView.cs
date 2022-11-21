using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.UI.Interfaces;
public interface IView<TDTO> where TDTO : IDTO {

    public void OpenWithIntent(ViewIntent intent, TDTO dtoToWorkWith);

}
