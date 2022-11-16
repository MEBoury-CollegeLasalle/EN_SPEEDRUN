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
    private ClinicService clinicService;

    private MainService() { 
        this.loginService = new LoginService();
        this.clinicService = new ClinicService();
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

    public ClinicService GetClinicService() {
        return this.clinicService;
    }

    public void InitApplication() {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }

    public void InitTempHasher() {
        ApplicationConfiguration.Initialize();
        Application.Run(new TempPasswordHasher());
    }

    public void ExitApplication() {
        Application.Exit();
    }
}
