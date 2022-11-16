using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;
public class LoginContext : DbContext {


    public DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=.\\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;TrustServerCertificate=true;");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    public UserDTO GetUserByUserName(string username) {
        Debug.WriteLine(username);
        List<UserDTO> userList = this.Users.ToList();
        foreach (UserDTO userobj in userList) {
            Console.WriteLine($"[{userobj.Username}]");
        }
        try {
            return this.Users
                .Where(user => user.Username == username)
                .Single();

        } catch (Exception ex) {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
            throw new UserNotFoundException($"User [{username}] not found.", username, ex);
        }
    }

}
