using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class ClinicDoctorDAO : AbstractDAO<ClinicDoctorDTO> {
    public ClinicDoctorDAO(IContext<ClinicDoctorDTO> context) : base(context) { }


}
