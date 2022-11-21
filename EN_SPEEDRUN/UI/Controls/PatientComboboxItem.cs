using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.UI.Controls;
public class PatientComboboxItem {

    public string DisplayName { get; set; }

    public PatientDTO? Patient { get; set; }

    public PatientComboboxItem(PatientDTO? patient) {
        if (patient is null) {
            this.DisplayName = "ANY";
        } else {
            this.DisplayName = patient.DisplayName;
        }
        this.Patient = patient;
    }
}
