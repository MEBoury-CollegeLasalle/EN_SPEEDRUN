using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.UI;
using EN_SPEEDRUN.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class AppointmentService : AbstractDtoService<AppointmentDTO> {
    private static AppointmentDetailsModal? modalWindow;

    public AppointmentService(IContext<AppointmentDTO> dbContext) : base(new AppointmentDAO(dbContext)) {
        
    }

    protected AppointmentDAO GetAppointmentDao() {
        return (AppointmentDAO) this.daoInstance;
    }

    public void OpenModalForDisplay(AppointmentDTO dto) {
        this.GetModalWindow().OpenWithIntent(ViewIntent.DISPLAY, dto);
    }

    public void OpenModalForCreation() {
        this.GetModalWindow().OpenWithIntent(ViewIntent.CREATION, new AppointmentDTO());
    }

    public void OpenModalForEdition(AppointmentDTO dto) {
        this.GetModalWindow().OpenWithIntent(ViewIntent.EDITION, dto);
    }

    public void OpenModalForDeletion(AppointmentDTO dto) {
        this.GetModalWindow().OpenWithIntent(ViewIntent.DELETION, dto);
    }

    public List<AppointmentDTO> GetFilteredClinicAppointments(
            ClinicDTO clinic,
            string? patientNameSearch = null,
            DoctorDTO? doctorCriterion = null,
            DateTime? afterDate = null,
            DateTime? beforeDate = null) {
        return this.GetAppointmentDao().GetFilteredClinicAppointments(clinic, patientNameSearch, doctorCriterion, afterDate, beforeDate);
    }

    private AppointmentDetailsModal GetModalWindow() {
        modalWindow ??= new AppointmentDetailsModal();
        return modalWindow;
    }
}
