using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.UI;
internal class DoctorComboboxItem {

    public string DisplayName { get; set; }

    public DoctorDTO? doctor { get; set; }

    public DoctorComboboxItem(DoctorDTO? doctor) {
        if (doctor is null) {
            this.DisplayName = "ANY";
        } else {
            this.DisplayName = doctor.FirstName + " " + doctor.LastName;
        }
        this.doctor = doctor;
    }
}
