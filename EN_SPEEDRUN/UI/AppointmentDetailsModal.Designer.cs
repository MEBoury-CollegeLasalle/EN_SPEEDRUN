using EN_SPEEDRUN.DataAccess.Dtos;

namespace EN_SPEEDRUN.UI;

partial class AppointmentDetailsModal {
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
            this.idTextLabel = new System.Windows.Forms.Label();
            this.statusTextLabel = new System.Windows.Forms.Label();
            this.doctorTextLabel = new System.Windows.Forms.Label();
            this.appTimeTextLabel = new System.Windows.Forms.Label();
            this.patientTextLabel = new System.Windows.Forms.Label();
            this.idValueLabel = new System.Windows.Forms.Label();
            this.statusSelector = new System.Windows.Forms.ComboBox();
            this.timeSelector = new System.Windows.Forms.ComboBox();
            this.doctorSelector = new System.Windows.Forms.ComboBox();
            this.patientSelector = new System.Windows.Forms.ComboBox();
            this.modalActionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idTextLabel
            // 
            this.idTextLabel.Location = new System.Drawing.Point(12, 9);
            this.idTextLabel.Name = "idTextLabel";
            this.idTextLabel.Size = new System.Drawing.Size(150, 25);
            this.idTextLabel.TabIndex = 0;
            this.idTextLabel.Text = "Internal ID:";
            this.idTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusTextLabel
            // 
            this.statusTextLabel.Location = new System.Drawing.Point(12, 84);
            this.statusTextLabel.Name = "statusTextLabel";
            this.statusTextLabel.Size = new System.Drawing.Size(150, 25);
            this.statusTextLabel.TabIndex = 1;
            this.statusTextLabel.Text = "Appointment status:";
            this.statusTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // doctorTextLabel
            // 
            this.doctorTextLabel.Location = new System.Drawing.Point(12, 152);
            this.doctorTextLabel.Name = "doctorTextLabel";
            this.doctorTextLabel.Size = new System.Drawing.Size(150, 25);
            this.doctorTextLabel.TabIndex = 2;
            this.doctorTextLabel.Text = "With:";
            this.doctorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // appTimeTextLabel
            // 
            this.appTimeTextLabel.Location = new System.Drawing.Point(12, 118);
            this.appTimeTextLabel.Name = "appTimeTextLabel";
            this.appTimeTextLabel.Size = new System.Drawing.Size(150, 25);
            this.appTimeTextLabel.TabIndex = 3;
            this.appTimeTextLabel.Text = "Appointment time:";
            this.appTimeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // patientTextLabel
            // 
            this.patientTextLabel.Location = new System.Drawing.Point(12, 51);
            this.patientTextLabel.Name = "patientTextLabel";
            this.patientTextLabel.Size = new System.Drawing.Size(150, 25);
            this.patientTextLabel.TabIndex = 4;
            this.patientTextLabel.Text = "Patient name:";
            this.patientTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idValueLabel
            // 
            this.idValueLabel.Location = new System.Drawing.Point(168, 9);
            this.idValueLabel.Name = "idValueLabel";
            this.idValueLabel.Size = new System.Drawing.Size(150, 25);
            this.idValueLabel.TabIndex = 5;
            this.idValueLabel.Text = "placeholder";
            this.idValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusSelector
            // 
            this.statusSelector.FormattingEnabled = true;
            this.statusSelector.Location = new System.Drawing.Point(168, 84);
            this.statusSelector.Name = "statusSelector";
            this.statusSelector.Size = new System.Drawing.Size(217, 28);
            this.statusSelector.TabIndex = 6;
            this.statusSelector.SelectedIndexChanged += new System.EventHandler(this.StatusSelector_SelectedIndexChanged);
            // 
            // timeSelector
            // 
            this.timeSelector.FormattingEnabled = true;
            this.timeSelector.Location = new System.Drawing.Point(168, 118);
            this.timeSelector.Name = "timeSelector";
            this.timeSelector.Size = new System.Drawing.Size(217, 28);
            this.timeSelector.TabIndex = 7;
            this.timeSelector.SelectedIndexChanged += new System.EventHandler(this.TimeSelector_SelectedIndexChanged);
            // 
            // doctorSelector
            // 
            this.doctorSelector.FormattingEnabled = true;
            this.doctorSelector.Location = new System.Drawing.Point(168, 152);
            this.doctorSelector.Name = "doctorSelector";
            this.doctorSelector.Size = new System.Drawing.Size(217, 28);
            this.doctorSelector.TabIndex = 8;
            this.doctorSelector.SelectedIndexChanged += new System.EventHandler(this.DoctorSelector_SelectedIndexChanged);
            // 
            // patientSelector
            // 
            this.patientSelector.FormattingEnabled = true;
            this.patientSelector.Location = new System.Drawing.Point(168, 50);
            this.patientSelector.Name = "patientSelector";
            this.patientSelector.Size = new System.Drawing.Size(217, 28);
            this.patientSelector.TabIndex = 10;
            this.patientSelector.SelectedIndexChanged += new System.EventHandler(this.patientSelector_SelectedIndexChanged);
            // 
            // modalActionButton
            // 
            this.modalActionButton.Location = new System.Drawing.Point(168, 201);
            this.modalActionButton.Name = "modalActionButton";
            this.modalActionButton.Size = new System.Drawing.Size(217, 40);
            this.modalActionButton.TabIndex = 11;
            this.modalActionButton.Text = "Placeholder";
            this.modalActionButton.UseVisualStyleBackColor = true;
            this.modalActionButton.Click += new System.EventHandler(this.modalActionButton_Click);
            // 
            // AppointmentDetailsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.modalActionButton);
            this.Controls.Add(this.patientSelector);
            this.Controls.Add(this.doctorSelector);
            this.Controls.Add(this.timeSelector);
            this.Controls.Add(this.statusSelector);
            this.Controls.Add(this.idValueLabel);
            this.Controls.Add(this.patientTextLabel);
            this.Controls.Add(this.appTimeTextLabel);
            this.Controls.Add(this.doctorTextLabel);
            this.Controls.Add(this.statusTextLabel);
            this.Controls.Add(this.idTextLabel);
            this.Name = "AppointmentDetailsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointment Details";
            this.ResumeLayout(false);

    }

    #endregion

    private Label idTextLabel;
    private Label statusTextLabel;
    private Label doctorTextLabel;
    private Label appTimeTextLabel;
    private Label patientTextLabel;
    private Label idValueLabel;
    private ComboBox statusSelector;
    private ComboBox timeSelector;
    private ComboBox doctorSelector;
    private ComboBox patientSelector;
    private Button modalActionButton;
}