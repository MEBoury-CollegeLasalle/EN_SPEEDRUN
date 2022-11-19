using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.Utils.Exceptions;
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
public partial class LoginWindow : Form {

    private static Color defaultTextColor = System.Drawing.SystemColors.ControlText;
    private static Color invalidTextColor = System.Drawing.Color.DarkRed;

    private LoginService loginService;

    public LoginWindow(LoginService loginService) {
        this.loginService = loginService;
        InitializeComponent();
        this.usernameField.TextChanged += this.UsernameField_TextChanged;
    }

    private void loginButton_Click(object sender, EventArgs e) {
        try {
            Console.WriteLine(this.usernameField.Text);
            Console.WriteLine(this.passwordField.Text); // who cares, its potatoes
            this.loginService.LogUserIn(this.usernameField.Text, this.passwordField.Text);
            this.DialogResult = DialogResult.OK;
        } catch (UserNotFoundException unfe) {
            this.usernameField.ForeColor = LoginWindow.invalidTextColor;
            this.usernameField.Refresh();
            this.usernameField.Focus();
            MessageBox.Show(unfe.Message);
        } catch (InvalidPasswordException ipe) {
            MessageBox.Show(ipe.Message);
            this.usernameField.Focus();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e) {
        MessageBox.Show("Login is required to use this application.\nApplication will now exit.");
        this.usernameField.Clear();
        this.passwordField.Clear();
        this.loginService.LogUserOut();
        MainService.GetInstance().ExitApplication();
    }

    private void UsernameField_TextChanged(object? sender, EventArgs e) {
        if (this.usernameField.ForeColor == LoginWindow.invalidTextColor) {
            this.usernameField.ForeColor = LoginWindow.defaultTextColor;
        }
    }

    private void PasswordField_KeyPressed(object sender, KeyEventArgs args) {
        if (args.KeyCode == Keys.Enter) {
            this.loginButton.PerformClick();
        }
    }
}
