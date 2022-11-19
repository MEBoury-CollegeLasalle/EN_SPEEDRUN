using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;

/// <summary>
/// 
/// </summary>
public class ClinicContext : DbContext, 
    IContext<StatusDTO>, 
    IContext<AppointmentTimeDTO>, 
    IContext<AddressDTO>, 
    IContext<ClinicDTO>, 
    IContext<PatientDTO>, 
    IContext<DoctorDTO>, 
    IContext<AppointmentDTO> {


    public DbSet<StatusDTO> Statuses { get; set; }
    public DbSet<AppointmentTimeDTO> AppointmentTimes { get; set; }
    public DbSet<AddressDTO> Addresses { get; set; }
    public DbSet<ClinicDTO> Clinics { get; set; }
    public DbSet<PatientDTO> Patients { get; set; }
    public DbSet<DoctorDTO> Doctors { get; set; }
    public DbSet<AppointmentDTO> Appointments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=.\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;TrustServerCertificate=true;");
    }


    DbSet<StatusDTO> IContext<StatusDTO>.GetDbSet() {
        return this.Statuses;
    }

    DbSet<AppointmentTimeDTO> IContext<AppointmentTimeDTO>.GetDbSet() {
        return this.AppointmentTimes;
    }

    DbSet<AddressDTO> IContext<AddressDTO>.GetDbSet() {
        return this.Addresses;
    }

    DbSet<ClinicDTO> IContext<ClinicDTO>.GetDbSet() {
        return this.Clinics;
    }

    DbSet<DoctorDTO> IContext<DoctorDTO>.GetDbSet() {
        return this.Doctors;
    }

    DbSet<PatientDTO> IContext<PatientDTO>.GetDbSet() {
        return this.Patients;
    }

    DbSet<AppointmentDTO> IContext<AppointmentDTO>.GetDbSet() {
        return this.Appointments;
    }
}
