using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public interface ILoginService : IService {

    public UserDTO? GetLoggedInUser();

    public UserDTO RequireLoggedInUser();

    public UserDTO LogUserIn(string username, string password, bool withActiveStatus = true);

    public void LogUserOut();

}
