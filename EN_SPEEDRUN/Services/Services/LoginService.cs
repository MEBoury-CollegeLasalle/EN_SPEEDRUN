using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Daos;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.UI;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class LoginService : ILoginService {

    private UserDTO? loggedInUser;
    private CryptographyService cryptographyService;

    public LoginService() {
        this.cryptographyService = CryptographyService.GetInstance();
    }

    public UserDTO? GetLoggedInUser() {
        return this.loggedInUser;
    }

    /// <summary>
    /// 
    /// </summary>
    public void RequireLoggedInUser() {
        if (!this.IsUserLoggedIn()) {
            this.OpenLoginModal();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <exception cref="InvalidPasswordException"></exception>
    public void LogUserIn(string username, string password) {
        using (UserDAO userDao = new UserDAO(new LoginContext())) {
            try {
                UserDTO user = userDao.GetByUsername(username);
                if (this.cryptographyService.ValidatePassword(password, user.PasswordHash)) {
                    userDao.UpdateUserLastLogin(user);
                    this.loggedInUser = user;

                } else {
                    throw new InvalidPasswordException("Invalid password");
                }
            } catch (UserNotFoundException unfe) {
                throw new UserNotFoundException("Invalid username", null, unfe);
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void LogUserOut() {
        this.loggedInUser = null;
        MainService.GetInstance().ExitApplication();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool IsUserLoggedIn() {
        return this.loggedInUser != null;
    }

    private void OpenLoginModal() {
        LoginWindow loginWindow = new LoginWindow(this);
        loginWindow.ShowDialog();
    }
}
