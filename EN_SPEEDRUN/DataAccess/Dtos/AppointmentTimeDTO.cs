using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("AppointmentTimes")]
public class AppointmentTimeDTO : IDto {

    [Key]
    public int Id { get; private set; }

    [Required]
    public TimeOnly timeOfDay { get; set; }

}
