using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Contexts;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Services.Services;
public class MainService {

    private static MainService? INSTANCE;

    private readonly ClinicContext appDbContext = null!;
    private readonly LoginContext loginContext = null!;
    private readonly ServiceSet services;

    private MainService() {
        this.services = new ServiceSet();
        this.loginContext = new LoginContext();
        this.appDbContext = new ClinicContext();
        this.services.Add(typeof(StatusDTO), new StatusService(this.appDbContext));
        this.services.Add(typeof(UserDTO), new LoginService(this.loginContext));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static MainService GetInstance() {
        INSTANCE ??= new MainService();
        return INSTANCE;
    }

    public void InitApplication() {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }

    public void InitMainServiceAfterLogin() {
        this.services.Add(typeof(ClinicDTO), new ClinicService(this.appDbContext));
        this.services.Add(typeof(AddressDTO), new AddressService(this.appDbContext));
        this.services.Add(typeof(DoctorDTO), new DoctorService(this.appDbContext));
        this.services.Add(typeof(PatientDTO), new PatientService(this.appDbContext));
        this.services.Add(typeof(AppointmentTimeDTO), new AppointmentTimeService(this.appDbContext));
        this.services.Add(typeof(AppointmentDTO), new AppointmentService(this.appDbContext));
    }

    public void InitTempHasher() {
        ApplicationConfiguration.Initialize();
        Application.Run(new TempPasswordHasher());
    }

    public void ExitApplication() {
        Application.Exit();
    }

    #region Sub-service accessors

    public AbstractDtoService<TDTO> GetDtoService<TDTO>() where TDTO : class, IDTO {
        return this.services.GetDtoService<TDTO>();
    }

    public ILoginService GetLoginService() {
        return (ILoginService) this.GetDtoService<UserDTO>();
    }

    public StatusService GetStatusService() {
        return (StatusService) this.GetDtoService<StatusDTO>();
    }

    public AddressService GetAddressService() {
        return (AddressService) this.GetDtoService<AddressDTO>();
    }

    public ClinicService GetClinicService() {
        return (ClinicService) this.GetDtoService<ClinicDTO>();
    }

    public DoctorService GetDoctorService() {
        return (DoctorService) this.GetDtoService<DoctorDTO>();
    }

    public PatientService GetPatientService() {
        return (PatientService) this.GetDtoService<PatientDTO>();
    }

    public AppointmentTimeService GetAppointmentTimeService() { 
        return (AppointmentTimeService) this.GetDtoService<AppointmentTimeDTO>();
    }

    public AppointmentService GetAppointmentService() {
        return (AppointmentService) this.GetDtoService<AppointmentDTO>();
    }

    #endregion

}
