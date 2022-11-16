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
public partial class TempPasswordHasher : Form {

    public TempPasswordHasher() {
        InitializeComponent();
    }

    private void buttonDoHash_Click(object sender, EventArgs e) {
        this.hashOutput.Text = CryptographyService.GetInstance().HashPassword(this.passwordInput.Text);
    }
}
