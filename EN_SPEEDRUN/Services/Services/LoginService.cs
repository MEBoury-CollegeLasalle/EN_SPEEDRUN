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
public class LoginService : AbstractDtoService<UserDTO>, ILoginService {

    private UserDTO? loggedInUser;
    private readonly CryptographyService cryptographyService;

    public LoginService(IContext<UserDTO> dbContext) : base(new UserDAO(dbContext)) {
        this.cryptographyService = CryptographyService.GetInstance();
    }

    protected UserDAO GetUserDao() {
        return (UserDAO) this.daoInstance;
    }

    public UserDTO? GetLoggedInUser() {
        return this.loggedInUser;
    }

    /// <summary>
    /// 
    /// </summary>
    public UserDTO RequireLoggedInUser() {
        return this.loggedInUser ?? this.OpenLoginModal();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="withActiveStatus"></param>
    /// <exception cref="InvalidStatusException"></exception>
    /// <exception cref="InvalidPasswordException"></exception>
    /// <exception cref="UserNotFoundException"></exception>
    public UserDTO LogUserIn(string username, string password, bool withActiveStatus = true) {
        try {
            StatusDTO validStatus = MainService.GetInstance().GetStatusService().GetActiveStatus();
            UserDTO user = this.GetUserDao().GetByUsername(username);
            if (withActiveStatus && !(user.StatusId == validStatus.Id)) {
                throw new InvalidStatusException("Invalid user status: {0} expected {1}.", MainService.GetInstance().GetStatusService().GetById(user.StatusId), validStatus);
            }
            if (this.cryptographyService.ValidatePassword(password, user.PasswordHash)) {
                this.GetUserDao().UpdateUserLastLogin(user);
                this.loggedInUser = user;
                MainService.GetInstance().InitMainServiceAfterLogin();
                return user;

            } else {
                throw new InvalidPasswordException("Invalid password");
            }
        } catch (UserNotFoundException unfe) {
            throw new UserNotFoundException("Invalid username", null, unfe);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public void LogUserOut() {
        this.loggedInUser = null;
        MainService.GetInstance().ExitApplication();
    }

    private UserDTO OpenLoginModal() {
        LoginWindow loginWindow = new LoginWindow();
        _ = loginWindow.ShowDialog();
        return loginWindow.LoggedInUser;
    }
}
