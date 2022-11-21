using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Patients")]
public class PatientDTO : IDTO {

    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    [StringLength(48)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(48)]
    public string LastName { get; set; }

    [Required]
    [StringLength(12)]
    public string HealthCardNumber { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }


    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }


    public List<AppointmentDTO> Appointments { get; set; }




    public PatientDTO(int statusId, string firstName, string lastName, string healthCardNumber) {

        this.StatusId = statusId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.HealthCardNumber = healthCardNumber;
    }

    public PatientDTO(
        string firstName, 
        string lastName, 
        string healthCardNumber, 
        StatusDTO status, 
        List<AppointmentDTO>? appointments = null
        ) {

        this.FirstName = firstName;
        this.LastName = lastName;
        this.HealthCardNumber = healthCardNumber;
        this.Status = status;
        this.StatusId = status.GetId();
        this.Appointments = appointments ?? new List<AppointmentDTO>();
    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }
}
