using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class MainService {

    private static MainService? INSTANCE;

    private ILoginService loginService;
    private ClinicService? clinicService;

    private MainService() {
        this.loginService = new LoginService();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static MainService GetInstance() {
        INSTANCE ??= new MainService();
        return INSTANCE;
    }


    public void InitMainServiceAfterLogin() {
        ClinicContext context = new ClinicContext();
        this.clinicService = new ClinicService(context);
    }


    public ILoginService GetLoginService() {
        return this.loginService;
    }

    public ClinicService GetClinicService() {
        // TODO: require login
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
