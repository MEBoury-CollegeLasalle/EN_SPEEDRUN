using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Interfaces;
using EN_SPEEDRUN.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public class LoginService : IService {

    private UserDTO? loggedInUser;
    private CryptographyService cryptographyService;

    private static LoginService INSTANCE;

    private LoginService() {
        this.cryptographyService = CryptographyService.GetInstance();
    }

    public static LoginService GetInstance() {
        return INSTANCE ??= new LoginService();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsLoggedIn() {
        return this.loggedInUser != null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <exception cref="InvalidPasswordException"></exception>
    public void LogUserIn(string username, string password) {
        using (LoginContext context = new LoginContext()) {
            UserDTO user = context.GetUserByUserName(username);
            if (this.cryptographyService.ValidatePassword(password, user)) {
                this.loggedInUser = user;
            } else {
                throw new InvalidPasswordException("Invalid password.");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void LogUserOut() {
        this.loggedInUser = null;
    }
}
