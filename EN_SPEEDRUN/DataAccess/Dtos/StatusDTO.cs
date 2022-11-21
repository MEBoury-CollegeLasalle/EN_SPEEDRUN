using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Statuses")]
public class StatusDTO : IDTO {

    public int Id { get; set; }

    [Column("StatusCode", TypeName = "nvarchar(16)")]
    public Statuses StatusCode { get; set; }


    public StatusDTO(Statuses statusCode) { 
        this.StatusCode = statusCode;
    }


    public int GetId() {
        return this.Id;
    }

    public enum Statuses {
        CREATED = 1,
        ACTIVE = 2,
        INACTIVE = 3,
        SUSPENDED = 4,
        DELETED = 5
    }
}
