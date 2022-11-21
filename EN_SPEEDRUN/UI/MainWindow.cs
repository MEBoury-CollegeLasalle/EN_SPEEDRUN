using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EN_SPEEDRUN.UI;
public partial class MainWindow : Form {

    public MainWindow() {
        this.InitializeComponent();
        this.Resize += new EventHandler(this.MainWindow_Resize);
        this.WindowState = FormWindowState.Maximized;
        this.listView1.DrawItem += new DrawListViewItemEventHandler(this.ListView1_DrawItem);
        this.listView1.DoubleClick += this.ListView1_DoubleClick;

        this.InitWindow();
    }

    private void InitWindow() {
        UserDTO user = MainService.GetInstance().GetLoginService().RequireLoggedInUser();
        this.userGreetingLabel.Text = "Hello " + user.Username + "!";
        this.FillClinicDisplayControls();
        this.ResetAppointmentFilters();
        this.FillAppointmentsList();
    }

    private void FillClinicDisplayControls() {
        this.clinicNameLabel.Text = MainService.GetInstance().GetClinicService().GetLoadedClinic().Name;
        this.clinicAddressLabel.Text = MainService.GetInstance().GetClinicService().GetLoadedClinic().Address.ToAddressString();

    }

    private void ResetAppointmentFilters() {
        this.patientNameFilter.Text = "";
        this.ResetDoctorFilterCombobox();
        this.doctorSelectorFilter.SelectedIndex = 0;
        this.lowerDateFilter.Value = DateTime.Now;
        this.upperDateFilter.Value = DateTime.Now.AddDays(7.0);
    }

    private void ResetDoctorFilterCombobox() {
        List<DoctorDTO> doctors = 
            MainService.GetInstance().GetDoctorService().GetClinicDoctors(
                MainService.GetInstance().GetClinicService().GetLoadedClinic().Id
            );
        this.doctorSelectorFilter.Items.Clear();
        this.doctorSelectorFilter.DisplayMember = "DisplayName";
        this.doctorSelectorFilter.ValueMember = "Doctor";
        _ = this.doctorSelectorFilter.Items.Add(new DoctorComboboxItem(null));
        foreach (DoctorDTO doc in doctors) {
            _ = this.doctorSelectorFilter.Items.Add(new DoctorComboboxItem(doc));
        }
    }

    private void FillAppointmentsList() {
        this.listView1.Items.Clear();
        List<AppointmentDTO> appointments =
            MainService.GetInstance().GetAppointmentService().GetFilteredClinicAppointments(
                MainService.GetInstance().GetClinicService().GetLoadedClinic(),
                this.patientNameFilter.Text,
                ((DoctorComboboxItem) this.doctorSelectorFilter.Items[this.doctorSelectorFilter.SelectedIndex]).Doctor,
                this.lowerDateFilter.Value,
                this.upperDateFilter.Value
                );

        foreach (AppointmentDTO appointment in appointments) {
            ListViewItem item = this.listView1.Items.Add(appointment.ToStringForListView());
            item.Tag = appointment;
            item.Position = new Point(item.Position.X + 5, item.Position.Y);
            if (appointment.Status.StatusCode != StatusDTO.Statuses.ACTIVE) {
                item.BackColor = Color.LightCoral;
            }
        }
    }

    #region Event Handlers

    private void MainWindow_Resize(object? sender, EventArgs args) {
        this.appointmentsPanel.Width = (int) (this.Width * 0.4);
        this.filtersPanel.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.filtersPanel.Height = (int) (this.appointmentsPanel.Height * 0.19);
        this.listView1.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.listView1.Height = (int) (this.appointmentsPanel.Height * 0.69);
        this.listView1.TileSize = new Size((int) (this.listView1.Width * 0.99), this.listView1.TileSize.Height);
        this.buttonLogout.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.buttonLogout.Height = (int) (this.appointmentsPanel.Height * 0.09);

        this.labelAppointmentFilters.Width = (int) (this.filtersPanel.Width - 6);
        this.patientNameFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.doctorSelectorFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.lowerDateFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.upperDateFilter.Width = (int) (this.filtersPanel.Width - 6);
    }


    private void buttonCreateAppointment_Click(object sender, EventArgs e) {
        MainService.GetInstance().GetAppointmentService().OpenModalForCreation();
    }

    private void ButtonEditAppointment_Click(object sender, EventArgs e) {
        if (listView1.SelectedItems.Count == 1) {
            MainService.GetInstance().GetAppointmentService().OpenModalForEdition((AppointmentDTO) this.listView1.SelectedItems[0].Tag);
        }

    }

    private void ButtonDeleteAppointment_Click(object sender, EventArgs e) {
        if (listView1.SelectedItems.Count == 1) {
            MainService.GetInstance().GetAppointmentService().OpenModalForDeletion((AppointmentDTO) this.listView1.SelectedItems[0].Tag);
        }

    }

    private void ButtonCreatePatient_Click(object sender, EventArgs e) {

    }

    private void ListView1_SelectedIndexChanged(object sender, EventArgs e) {
        if (this.listView1.SelectedIndices.Count > 0) {
            this.buttonEditAppointment.Enabled = true;
            this.buttonDeleteAppointment.Enabled = true;
        } else {
            this.buttonEditAppointment.Enabled = false;
            this.buttonDeleteAppointment.Enabled = false;
        }
    }

    private void ListView1_DrawItem(object? sender, DrawListViewItemEventArgs e) {
        e.DrawDefault = true;
        e.Graphics.DrawRectangle(Pens.LightBlue, e.Bounds);
    }

    private void ListView1_DoubleClick(object? sender, EventArgs e) {
        if (listView1.SelectedItems.Count == 1) {
            MainService.GetInstance().GetAppointmentService().OpenModalForDisplay((AppointmentDTO) this.listView1.SelectedItems[0].Tag);
        }
    }

    private void ButtonLogout_Click(object sender, EventArgs e) {
        MainService.GetInstance().GetLoginService().LogUserOut();
    }

    private void PatientNameFilter_TextChanged(object sender, EventArgs e) {
        this.FillAppointmentsList();
    }

    private void DoctorSelectorFilter_SelectedIndexChanged(object sender, EventArgs e) {
        this.FillAppointmentsList();
    }

    private void LowerDateFilter_ValueChanged(object sender, EventArgs e) {
        this.FillAppointmentsList();
    }

    private void UpperDateFilter_ValueChanged(object sender, EventArgs e) {
        this.FillAppointmentsList();
    }

    #endregion

}
