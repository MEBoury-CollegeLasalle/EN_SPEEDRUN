using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Services.Services;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Daos;
public class UserDAO : AbstractDAO<UserDTO> {

    public UserDAO(IContext<UserDTO> context) : base(context) { }

    public UserDTO GetByUsername(string username) {
        try {
            return this.GetContext().GetDbSet()
                .Where(user => user.Username == username)
                .Single();
        } catch (Exception ex) {
            throw new UserNotFoundException($"User [{username}] not found.", username, ex);
        }
    }

    public void UpdateUserLastLogin(UserDTO user, DateTime? newLastLoginTime = null) {
        user.LastLogin = newLastLoginTime ?? DateTime.Now;
        this.GetContext().SaveChanges();
    }

}
