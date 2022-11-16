namespace EN_SPEEDRUN.UI;

partial class TempPasswordHasher {
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
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.buttonDoHash = new System.Windows.Forms.Button();
            this.hashOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(50, 45);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PlaceholderText = "Clear Password";
            this.passwordInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordInput.Size = new System.Drawing.Size(616, 27);
            this.passwordInput.TabIndex = 0;
            this.passwordInput.UseSystemPasswordChar = true;
            // 
            // buttonDoHash
            // 
            this.buttonDoHash.Location = new System.Drawing.Point(50, 90);
            this.buttonDoHash.Name = "buttonDoHash";
            this.buttonDoHash.Size = new System.Drawing.Size(94, 29);
            this.buttonDoHash.TabIndex = 1;
            this.buttonDoHash.Text = "Hash it!";
            this.buttonDoHash.UseVisualStyleBackColor = true;
            this.buttonDoHash.Click += new System.EventHandler(this.buttonDoHash_Click);
            // 
            // hashOutput
            // 
            this.hashOutput.Location = new System.Drawing.Point(50, 138);
            this.hashOutput.Name = "hashOutput";
            this.hashOutput.PlaceholderText = "Hashed Password";
            this.hashOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hashOutput.Size = new System.Drawing.Size(616, 27);
            this.hashOutput.TabIndex = 2;
            // 
            // TempPasswordHasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hashOutput);
            this.Controls.Add(this.buttonDoHash);
            this.Controls.Add(this.passwordInput);
            this.Name = "TempPasswordHasher";
            this.Text = "TempPasswordHasher";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox passwordInput;
    private Button buttonDoHash;
    private TextBox hashOutput;
}