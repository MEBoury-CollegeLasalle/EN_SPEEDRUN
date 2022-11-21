namespace EN_SPEEDRUN.UI;

partial class MainWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.appointmentsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filtersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelAppointmentFilters = new System.Windows.Forms.Label();
            this.patientNameFilter = new System.Windows.Forms.TextBox();
            this.doctorSelectorFilter = new System.Windows.Forms.ComboBox();
            this.lowerDateFilter = new System.Windows.Forms.DateTimePicker();
            this.upperDateFilter = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            this.clinicNameLabel = new System.Windows.Forms.Label();
            this.clinicAddressLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonDeleteAppointment = new System.Windows.Forms.Button();
            this.buttonEditAppointment = new System.Windows.Forms.Button();
            this.buttonCreatePatient = new System.Windows.Forms.Button();
            this.buttonCreateAppointment = new System.Windows.Forms.Button();
            this.userGreetingLabel = new System.Windows.Forms.Label();
            this.appointmentsPanel.SuspendLayout();
            this.filtersPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentsPanel
            // 
            this.appointmentsPanel.Controls.Add(this.filtersPanel);
            this.appointmentsPanel.Controls.Add(this.listView1);
            this.appointmentsPanel.Controls.Add(this.buttonLogout);
            this.appointmentsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.appointmentsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.appointmentsPanel.Location = new System.Drawing.Point(817, 0);
            this.appointmentsPanel.Name = "appointmentsPanel";
            this.appointmentsPanel.Size = new System.Drawing.Size(250, 587);
            this.appointmentsPanel.TabIndex = 2;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Controls.Add(this.labelAppointmentFilters);
            this.filtersPanel.Controls.Add(this.patientNameFilter);
            this.filtersPanel.Controls.Add(this.doctorSelectorFilter);
            this.filtersPanel.Controls.Add(this.lowerDateFilter);
            this.filtersPanel.Controls.Add(this.upperDateFilter);
            this.filtersPanel.Location = new System.Drawing.Point(3, 3);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(250, 195);
            this.filtersPanel.TabIndex = 1;
            // 
            // labelAppointmentFilters
            // 
            this.labelAppointmentFilters.Location = new System.Drawing.Point(3, 0);
            this.labelAppointmentFilters.Name = "labelAppointmentFilters";
            this.labelAppointmentFilters.Size = new System.Drawing.Size(244, 25);
            this.labelAppointmentFilters.TabIndex = 0;
            this.labelAppointmentFilters.Text = "Appointment Filters";
            this.labelAppointmentFilters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patientNameFilter
            // 
            this.patientNameFilter.Location = new System.Drawing.Point(3, 28);
            this.patientNameFilter.Name = "patientNameFilter";
            this.patientNameFilter.Size = new System.Drawing.Size(244, 27);
            this.patientNameFilter.TabIndex = 1;
            this.patientNameFilter.TextChanged += new System.EventHandler(this.PatientNameFilter_TextChanged);
            // 
            // doctorSelectorFilter
            // 
            this.doctorSelectorFilter.FormattingEnabled = true;
            this.doctorSelectorFilter.Location = new System.Drawing.Point(3, 61);
            this.doctorSelectorFilter.Name = "doctorSelectorFilter";
            this.doctorSelectorFilter.Size = new System.Drawing.Size(244, 28);
            this.doctorSelectorFilter.TabIndex = 2;
            this.doctorSelectorFilter.SelectedIndexChanged += new System.EventHandler(this.DoctorSelectorFilter_SelectedIndexChanged);
            // 
            // lowerDateFilter
            // 
            this.lowerDateFilter.Location = new System.Drawing.Point(3, 95);
            this.lowerDateFilter.Name = "lowerDateFilter";
            this.lowerDateFilter.Size = new System.Drawing.Size(250, 27);
            this.lowerDateFilter.TabIndex = 3;
            this.lowerDateFilter.ValueChanged += new System.EventHandler(this.LowerDateFilter_ValueChanged);
            // 
            // upperDateFilter
            // 
            this.upperDateFilter.Location = new System.Drawing.Point(3, 128);
            this.upperDateFilter.Name = "upperDateFilter";
            this.upperDateFilter.Size = new System.Drawing.Size(250, 27);
            this.upperDateFilter.TabIndex = 4;
            this.upperDateFilter.ValueChanged += new System.EventHandler(this.UpperDateFilter_ValueChanged);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 204);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(250, 262);
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(268, 50);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonLogout.Location = new System.Drawing.Point(3, 472);
            this.buttonLogout.MaximumSize = new System.Drawing.Size(300, 30);
            this.buttonLogout.MinimumSize = new System.Drawing.Size(100, 16);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(250, 30);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelFooter.Location = new System.Drawing.Point(0, 562);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(817, 25);
            this.labelFooter.TabIndex = 3;
            this.labelFooter.Text = "Footer";
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clinicNameLabel
            // 
            this.clinicNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.clinicNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clinicNameLabel.Location = new System.Drawing.Point(0, 0);
            this.clinicNameLabel.Name = "clinicNameLabel";
            this.clinicNameLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.clinicNameLabel.Size = new System.Drawing.Size(817, 50);
            this.clinicNameLabel.TabIndex = 4;
            this.clinicNameLabel.Text = "clinicNamePlaceholder";
            this.clinicNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clinicAddressLabel
            // 
            this.clinicAddressLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.clinicAddressLabel.Location = new System.Drawing.Point(0, 50);
            this.clinicAddressLabel.Name = "clinicAddressLabel";
            this.clinicAddressLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.clinicAddressLabel.Size = new System.Drawing.Size(817, 25);
            this.clinicAddressLabel.TabIndex = 5;
            this.clinicAddressLabel.Text = "clinicAddressPlaceholder";
            this.clinicAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonDeleteAppointment);
            this.mainPanel.Controls.Add(this.buttonEditAppointment);
            this.mainPanel.Controls.Add(this.buttonCreatePatient);
            this.mainPanel.Controls.Add(this.buttonCreateAppointment);
            this.mainPanel.Controls.Add(this.userGreetingLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(817, 487);
            this.mainPanel.TabIndex = 6;
            // 
            // buttonDeleteAppointment
            // 
            this.buttonDeleteAppointment.Location = new System.Drawing.Point(12, 201);
            this.buttonDeleteAppointment.Name = "buttonDeleteAppointment";
            this.buttonDeleteAppointment.Size = new System.Drawing.Size(200, 30);
            this.buttonDeleteAppointment.TabIndex = 4;
            this.buttonDeleteAppointment.Text = "Delete Appointment";
            this.buttonDeleteAppointment.UseVisualStyleBackColor = true;
            this.buttonDeleteAppointment.Click += new System.EventHandler(this.ButtonDeleteAppointment_Click);
            // 
            // buttonEditAppointment
            // 
            this.buttonEditAppointment.Location = new System.Drawing.Point(12, 165);
            this.buttonEditAppointment.Name = "buttonEditAppointment";
            this.buttonEditAppointment.Size = new System.Drawing.Size(200, 30);
            this.buttonEditAppointment.TabIndex = 3;
            this.buttonEditAppointment.Text = "Edit Appointment";
            this.buttonEditAppointment.UseVisualStyleBackColor = true;
            this.buttonEditAppointment.Click += new System.EventHandler(this.ButtonEditAppointment_Click);
            // 
            // buttonCreatePatient
            // 
            this.buttonCreatePatient.Location = new System.Drawing.Point(12, 75);
            this.buttonCreatePatient.Name = "buttonCreatePatient";
            this.buttonCreatePatient.Size = new System.Drawing.Size(200, 30);
            this.buttonCreatePatient.TabIndex = 2;
            this.buttonCreatePatient.Text = "Register New Patient";
            this.buttonCreatePatient.UseVisualStyleBackColor = true;
            this.buttonCreatePatient.Click += new System.EventHandler(this.ButtonCreatePatient_Click);
            // 
            // buttonCreateAppointment
            // 
            this.buttonCreateAppointment.Location = new System.Drawing.Point(12, 129);
            this.buttonCreateAppointment.Name = "buttonCreateAppointment";
            this.buttonCreateAppointment.Size = new System.Drawing.Size(200, 30);
            this.buttonCreateAppointment.TabIndex = 1;
            this.buttonCreateAppointment.Text = "Create Appointment";
            this.buttonCreateAppointment.UseVisualStyleBackColor = true;
            this.buttonCreateAppointment.Click += new System.EventHandler(this.buttonCreateAppointment_Click);
            // 
            // userGreetingLabel
            // 
            this.userGreetingLabel.AutoSize = true;
            this.userGreetingLabel.Location = new System.Drawing.Point(12, 33);
            this.userGreetingLabel.Name = "userGreetingLabel";
            this.userGreetingLabel.Size = new System.Drawing.Size(87, 20);
            this.userGreetingLabel.TabIndex = 0;
            this.userGreetingLabel.Text = "Hello Mr. X!";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 587);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.clinicAddressLabel);
            this.Controls.Add(this.clinicNameLabel);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.appointmentsPanel);
            this.Name = "MainWindow";
            this.Text = "Normslabs - Clinic Management System v0.3.5";
            this.appointmentsPanel.ResumeLayout(false);
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private FlowLayoutPanel appointmentsPanel;
    private ListView listView1;
    private Label labelFooter;
    private Label clinicNameLabel;
    private FlowLayoutPanel filtersPanel;
    private Button buttonLogout;
    private Label clinicAddressLabel;
    private Panel mainPanel;
    private Button buttonCreateAppointment;
    private Label userGreetingLabel;
    private Label labelAppointmentFilters;
    private TextBox patientNameFilter;
    private ComboBox doctorSelectorFilter;
    private DateTimePicker lowerDateFilter;
    private DateTimePicker upperDateFilter;
    private Button buttonDeleteAppointment;
    private Button buttonEditAppointment;
    private Button buttonCreatePatient;
}