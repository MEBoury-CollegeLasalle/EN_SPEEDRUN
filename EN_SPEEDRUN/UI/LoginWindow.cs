using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.Utils.Exceptions;
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
public partial class LoginWindow : Form {

    private static readonly Color DEFAULT_TEXT_COLOR = System.Drawing.SystemColors.ControlText;
    private static readonly Color INVALID_TEXT_COLOR = System.Drawing.Color.Red;
    public UserDTO LoggedInUser { get; set; } = null!;

    public LoginWindow() {
        InitializeComponent();
        this.usernameField.TextChanged += this.UsernameField_TextChanged;
    }

    private void LoginButton_Click(object sender, EventArgs e) {
        try {
            this.LoggedInUser = MainService.GetInstance().GetLoginService().LogUserIn(this.usernameField.Text, this.passwordField.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        } catch (UserNotFoundException unfe) {
            this.usernameField.ForeColor = LoginWindow.INVALID_TEXT_COLOR;
            this.usernameField.Refresh();
            this.usernameField.Focus();
            MessageBox.Show(unfe.Message);
        } catch (InvalidPasswordException ipe) {
            MessageBox.Show(ipe.Message);
            this.usernameField.Focus();
        } catch (Exception ex) {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
        }
    }

    private void cancelButton_Click(object sender, EventArgs e) {
        MessageBox.Show("Login is required to use this application.\nApplication will now exit.");
        this.usernameField.Clear();
        this.passwordField.Clear();
        MainService.GetInstance().GetLoginService().LogUserOut();
        MainService.GetInstance().ExitApplication();
    }

    private void UsernameField_TextChanged(object? sender, EventArgs e) {
        if (this.usernameField.ForeColor == LoginWindow.INVALID_TEXT_COLOR) {
            this.usernameField.ForeColor = LoginWindow.DEFAULT_TEXT_COLOR;
        }
    }

    private void PasswordField_KeyPressed(object sender, KeyEventArgs args) {
        if (args.KeyCode == Keys.Enter) {
            this.loginButton.PerformClick();
        }
    }
}
