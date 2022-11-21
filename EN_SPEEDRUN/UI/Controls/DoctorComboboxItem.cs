using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.UI.Controls;
internal class DoctorComboboxItem {

    public string DisplayName { get; set; }

    public DoctorDTO? Doctor { get; set; }

    public DoctorComboboxItem(DoctorDTO? doctor) {
        if (doctor is null) {
            this.DisplayName = "ANY";
        } else {
            this.DisplayName = doctor.DisplayName;
        }
        this.Doctor = doctor;
    }
}
