using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;
public class LoginContext : DbContext {


    public DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=.\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;");
    }

    public UserDTO GetUserByUserName(string username) {
        try {
            return this.Users
                .Where(user => user.Username.Equals(username))
                .Include(user => user.Clinic)
                .Single();

        } catch (Exception ex) {
            throw new UserNotFoundException($"User [{username}] not found.", username, ex);
        }
    }



}
