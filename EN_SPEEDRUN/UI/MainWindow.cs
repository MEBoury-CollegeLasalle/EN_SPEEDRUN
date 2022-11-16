using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services;
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

    private ClinicDTO loadedClinic;

    public MainWindow() {
        InitializeComponent();
        this.Resize += new EventHandler(MainWindow_Resize);
        this.WindowState = FormWindowState.Maximized;

        MainService.GetInstance().GetLoginService().RequireLoggedInUser();
        this.LoadUserClinic(MainService.GetInstance().GetLoginService().GetLoggedInUser());
    }

    private void MainWindow_Resize(object sender, EventArgs args) {
        this.appointmentsPanel.Width = (int) (this.Width * 0.4);
        this.filtersPanel.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.filtersPanel.Height = (int) (this.appointmentsPanel.Height * 0.19);
        this.listView1.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.listView1.Height = (int) (this.appointmentsPanel.Height * 0.69);
        this.buttonLogout.Width = (int) (this.appointmentsPanel.Width * 0.95);
        this.buttonLogout.Height = (int) (this.appointmentsPanel.Height * 0.09);

        this.labelAppointmentFilters.Width = (int) (this.filtersPanel.Width - 6);
        this.patientNameFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.doctorSelectorFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.lowerDateFilter.Width = (int) (this.filtersPanel.Width - 6);
        this.upperDateFilter.Width = (int) (this.filtersPanel.Width - 6);
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

    }

    private void buttonLogout_Click(object sender, EventArgs e) {
        MainService.GetInstance().GetLoginService().LogUserOut();
    }

    private void patientNameFilter_TextChanged(object sender, EventArgs e) {

    }

    private void LoadUserClinic(UserDTO? user) {
        if (user is not null) {
            this.userGreetingLabel.Text = "Hello " + user.Username + "!";
            this.loadedClinic = MainService.GetInstance().GetClinicService().LoadClinicForUser(user);
            this.FillClinicDisplayControls();
            this.ResetAppointmentFilters();
        }
    }

    private void FillClinicDisplayControls() {
        this.clinicNameLabel.Text = this.loadedClinic.Name;
        // TODO: check if address is loaded and if not, load address.
        this.clinicAddressLabel.Text = this.loadedClinic.Address.ToAddressString();

    }

    private void ResetAppointmentFilters() {
        this.patientNameFilter.Text = "";
        this.ResetDoctorFilterCombobox();
        this.doctorSelectorFilter.SelectedIndex = 0;
        this.lowerDateFilter.Value = DateTime.Now;
        this.upperDateFilter.Value = (DateTime.Now).AddDays(7.0);
    }

    private void ResetDoctorFilterCombobox() {
        List<DoctorDTO> doctors = this.loadedClinic.GetDoctors();
        this.doctorSelectorFilter.Items.Clear();
        this.doctorSelectorFilter.DisplayMember = "DisplayName";
        this.doctorSelectorFilter.Items.Add(new DoctorComboboxItem(null));
        foreach (DoctorDTO doc in doctors) {
            this.doctorSelectorFilter.Items.Add(new DoctorComboboxItem(doc));
        }
    }
}
