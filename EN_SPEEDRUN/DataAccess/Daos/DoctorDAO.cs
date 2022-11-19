﻿using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class DoctorDAO : AbstractDAO<DoctorDTO> {

    public DoctorDAO(IContext<DoctorDTO> context) : base(context) { }

}
