using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Interfaces;
public interface ILoginService : IService {

    public void RequireLoggedInUser();

    public void LogUserIn(string username, string password);

    public void LogUserOut();

}
