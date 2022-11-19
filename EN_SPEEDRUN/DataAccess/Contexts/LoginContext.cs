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
public class LoginContext : DbContext, IContext<UserDTO> {


    public DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=.\\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;TrustServerCertificate=true;");
    }

    DbSet<UserDTO> IContext<UserDTO>.GetDbSet() {
        return this.Users;
    }
}
