using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.UI.Controls;
using EN_SPEEDRUN.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EN_SPEEDRUN.UI;
public partial class AppointmentDetailsModal : AbstractView<AppointmentDTO> {
    private bool suppessComboboxEvents = false;

    public AppointmentDetailsModal() : base() {
        InitializeComponent();
        this.doctorSelector.DisplayMember = "DisplayName";
        this.doctorSelector.ValueMember = "Doctor";
        this.patientSelector.DisplayMember = "DisplayName";
        this.patientSelector.ValueMember = "Patient";
    }



    protected override void RenderForCreation() {
        // TODO: null checks
        this.modalActionButton.Text = "Create!";
        this.LoadStatuses();
        this.LoadClinicDoctors();
        this.LoadAppointmentTimes();
        this.LoadPatients();
        this.suppessComboboxEvents = true;
        this.idValueLabel.Text = this.WorkInstance.Id.ToString("D9");
        this.patientSelector.Enabled = true;
        this.statusSelector.Enabled = true;
        this.doctorSelector.Enabled = true;
        this.timeSelector.Enabled = true;
        this.suppessComboboxEvents = false;
        this.ShowDialog();
    }

    protected override void RenderForDisplay() {
        // TODO: null checks
        this.modalActionButton.Text = "Close";
        this.LoadStatuses();
        this.LoadClinicDoctors();
        this.LoadAppointmentTimes();
        this.LoadPatients();
        this.suppessComboboxEvents = true;
        this.idValueLabel.Text = this.WorkInstance.Id.ToString("D9");
        this.patientSelector.SelectedIndex = this.patientSelector.Items.IndexOf(this.WorkInstance.Patient);
        this.statusSelector.SelectedIndex = this.statusSelector.Items.IndexOf(this.WorkInstance.Status);
        this.doctorSelector.SelectedIndex = this.doctorSelector.Items.IndexOf(this.WorkInstance.Doctor);
        this.timeSelector.SelectedIndex = this.timeSelector.Items.IndexOf(this.WorkInstance.AppointmentTime);
        this.patientSelector.Enabled = false;
        this.statusSelector.Enabled = false;
        this.doctorSelector.Enabled = false;
        this.timeSelector.Enabled = false;
        this.suppessComboboxEvents = false;
        this.ShowDialog();
    }
    
    protected override void RenderForEdition() {
        // TODO: null checks
        this.modalActionButton.Text = "Save Changes";
        this.suppessComboboxEvents = true;
        this.idValueLabel.Text = this.WorkInstance.Id.ToString("D9");
        this.patientSelector.Enabled = false;
        this.patientSelector.Text = this.WorkInstance.Patient.DisplayName;
        this.statusSelector.Enabled = true;
        this.statusSelector.SelectedValue = this.WorkInstance.Status;
        this.doctorSelector.Enabled = false;
        this.doctorSelector.SelectedValue = this.WorkInstance.Doctor;
        this.timeSelector.Enabled = true;
        this.timeSelector.SelectedValue = this.WorkInstance.AppointmentTime;
        this.suppessComboboxEvents = false;
        this.ShowDialog();
    }

    protected override void RenderForDeletion() {
        // TODO: null checks
        this.modalActionButton.Text = "Delete";
        this.LoadStatuses();
        this.LoadClinicDoctors();
        this.LoadAppointmentTimes();
        this.LoadPatients();
        this.suppessComboboxEvents = true;
        this.idValueLabel.Text = this.WorkInstance.Id.ToString("D9");
        this.patientSelector.SelectedIndex = this.patientSelector.Items.IndexOf(this.WorkInstance.Patient);
        this.statusSelector.SelectedIndex = this.statusSelector.Items.IndexOf(this.WorkInstance.Status);
        this.doctorSelector.SelectedIndex = this.doctorSelector.Items.IndexOf(this.WorkInstance.Doctor);
        this.timeSelector.SelectedIndex = this.timeSelector.Items.IndexOf(this.WorkInstance.AppointmentTime);
        this.patientSelector.Enabled = false;
        this.statusSelector.Enabled = false;
        this.doctorSelector.Enabled = false;
        this.timeSelector.Enabled = false;
        this.suppessComboboxEvents = false;
        this.ShowDialog();
    }

    private void modalActionButton_Click(object sender, EventArgs e) {
        switch (this.WorkIntent) {
            case Enums.ViewIntent.CREATION:
                this.TriggerDtoCreation();
                break;
            case Enums.ViewIntent.DISPLAY:
                this.DialogResult = DialogResult.Cancel;
                break;
            case Enums.ViewIntent.EDITION:
                this.TriggerDtoModificationsSave();
                break;
            case Enums.ViewIntent.DELETION:
                this.TriggerDtoDeletion();
                break;
        }
    }

    protected override void TriggerDtoCreation() {
        throw new NotImplementedException();
    }

    protected override void TriggerDtoModificationsSave() {
        throw new NotImplementedException();
    }

    protected override void TriggerDtoDeletion() {
        throw new NotImplementedException();
    }

    private void StatusSelector_SelectedIndexChanged(object sender, EventArgs e) {
        if (!this.suppessComboboxEvents) {
            this.WorkInstance.Status = (StatusDTO) this.statusSelector.Items[this.statusSelector.SelectedIndex];
        }
    }

    private void TimeSelector_SelectedIndexChanged(object sender, EventArgs e) {
        if (!this.suppessComboboxEvents) {
            this.WorkInstance.AppointmentTime = (AppointmentTimeDTO) this.timeSelector.Items[this.timeSelector.SelectedIndex];
        }
    }

    private void DoctorSelector_SelectedIndexChanged(object sender, EventArgs e) {
        if (!this.suppessComboboxEvents) {
            this.WorkInstance.Doctor = ((DoctorComboboxItem) this.doctorSelector.Items[this.doctorSelector.SelectedIndex]).Doctor;
        }
    }

    private void patientSelector_SelectedIndexChanged(object sender, EventArgs e) {
        if (!this.suppessComboboxEvents) {
            this.WorkInstance.Patient = ((PatientComboboxItem) this.patientSelector.Items[this.patientSelector.SelectedIndex]).Patient;
        }
    }

    private void LoadStatuses() {
        List<StatusDTO> statusList = MainService.GetInstance().GetStatusService().GetAll();
        foreach (StatusDTO status in statusList) {
            this.statusSelector.Items.Add(status);
        }
    }

    private void LoadPatients() {
        List<PatientDTO> patients = MainService.GetInstance().GetPatientService().GetAll();
        foreach (PatientDTO patient in patients) {
            _ = this.patientSelector.Items.Add(new PatientComboboxItem(patient));
        }
    }

    private void LoadClinicDoctors() {
        List<DoctorDTO> doctorsList = MainService.GetInstance().GetClinicService().GetLoadedClinic().GetDoctors();
        Debug.WriteLine("Doctors list:");
        foreach (DoctorDTO doc in doctorsList) {
            Debug.WriteLine(doc.DisplayName);
            _ = this.doctorSelector.Items.Add(new DoctorComboboxItem(doc));
        }
    }

    private void LoadAppointmentTimes() {
        List<AppointmentTimeDTO> appointmentTimes = MainService.GetInstance().GetAppointmentTimeService().GetAll();
        foreach (AppointmentTimeDTO appTime in appointmentTimes) {
            this.timeSelector.Items.Add(appTime);
        }
    }
}
