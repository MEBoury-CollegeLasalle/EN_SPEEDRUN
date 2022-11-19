using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class PatientDAO : AbstractDAO<PatientDTO> {

    public PatientDAO(IContext<PatientDTO> context) : base(context) { }

}
