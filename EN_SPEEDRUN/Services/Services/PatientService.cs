using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class PatientService : AbstractDtoService<PatientDTO> {

    public PatientService(IContext<PatientDTO> dbContext) : base(new PatientDAO(dbContext)) { }

    protected PatientDAO GetPatientDao() {
        return (PatientDAO) this.daoInstance;
    }

    public PatientDTO CreateNewPatient(
        string firstName,
        string lastName,
        string healthCardNumber,
        StatusDTO status,
        List<AppointmentDTO>? appointments = null) {

        PatientDTO newPatient = new PatientDTO(firstName, lastName, healthCardNumber, status, appointments);
        this.GetPatientDao().Save(newPatient);
        return newPatient;
    }

}
