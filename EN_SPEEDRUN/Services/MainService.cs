using EN_SPEEDRUN.Services.Interfaces;
using EN_SPEEDRUN.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services;
public class MainService {

    private static MainService INSTANCE;

    private ILoginService loginService;

    private MainService() { 
        this.loginService = new LoginService();
    }

    public static MainService GetInstance() {
        if (INSTANCE is null) {
            INSTANCE = new MainService();
        }
        return INSTANCE;
    }


    public ILoginService GetLoginService() {
        return this.loginService;
    }

    public void InitApplication() {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }

    public void ExitApplication() {
        Application.Exit();
    }
}
