using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Statuses")]
public class StatusDTO : IDto {

    public int Id { get; set; }

    [Column("StatusCode", TypeName = "nvarchar(16)")]
    public Statuses StatusCode { get; set; }


    public enum Statuses {
        CREATED = 0,
        ACTIVE = 1,
        INACTIVE = 2,
        SUSPENDED = 3,
        DELETED = 4
    }
}
