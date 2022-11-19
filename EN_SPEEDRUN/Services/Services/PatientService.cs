using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class PatientService {

    private static PatientService INSTANCE;

    private PatientService() {

    }

    public static PatientService GetInstance() {
        if (INSTANCE is null) {
            INSTANCE = new PatientService();
        }
        return INSTANCE;
    }


}
