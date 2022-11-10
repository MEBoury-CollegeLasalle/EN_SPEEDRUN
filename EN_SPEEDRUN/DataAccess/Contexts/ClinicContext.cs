using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Contexts;
public class ClinicContext : DbContext {

    public DbSet<StatusDTO> Statuses { get; set; }
    public DbSet<AddressDTO> Addresses { get; set; }
    public DbSet<ClinicDTO> Clinics { get; set; }
    public DbSet<PatientDTO> Patients { get; set; }
    public DbSet<DoctorDTO> Doctors { get; set; }
    public DbSet<AppointmentDTO> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=.\SQL2019EXPRESS;Database=db_speedrun_en;Integrated security=true;");
    }

    public ClinicDTO GetClinicForAppUser(UserDTO user) {
        if (user is null) {
            throw new InvalidNullArgumentException(
                "Null user passed.",
                "user",
                this.GetType().FullName + "GetClinicForAppUser"
                );
        }
        // TODO: handle clinic not found case?
        ClinicDTO clinic = this.Clinics
            .Where(clinic => clinic.Id == user.ClinicId)
            .Include(clinic => clinic.Doctors)
            .Single();
        return clinic;
    }
}
