using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Users", Schema = "dbo")]
public class UserDTO : IDTO {

    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int ClinicId { get; set; }

    [Required]
    [StringLength(32)]
    public string Username { get; set; }

    [Required]
    [StringLength(128)]
    public string PasswordHash { get; set; }

    [Precision(6)]
    public DateTime? LastLogin { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("ClinicId")]
    public ClinicDTO Clinic { get; set; }

    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }




    public UserDTO(string username, string passwordHash, StatusDTO status, ClinicDTO clinic) {
        this.Username = username;
        this.PasswordHash = passwordHash;
        this.Status = status;
        this.StatusId = status.GetId();
        this.Clinic = clinic;
        this.ClinicId = clinic.GetId();
    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }
}
