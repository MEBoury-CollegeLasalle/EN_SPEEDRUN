using EN_SPEEDRUN.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("AppointmentTimes")]
public class AppointmentTimeDTO : IDTO {

    private int hours;
    private int minutes;

    [Key]
    public int Id { get; private set; }

    [Required]
    public int Hours { 
        get { return this.hours; }
        set { this.hours = this.ValidateHours(value); }
    }

    [Required]
    public int Minutes {
        get { return this.minutes; }
        set { this.minutes = this.ValidateMinutes(value); }
    }



    public AppointmentTimeDTO(int hours, int minutes) {
        this.Hours = hours;
        this.Minutes = minutes;
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }


    /// <summary>
    /// Validates a <c>Hours</c> value for a <see cref="AppointmentTimeDTO.Hours"/> instance.
    /// Returns the passed value to check if it is valid. Throws exceptions otherwise.
    /// </summary>
    /// <param name="hours">The <c>Hours</c> value to validate.</param>
    /// <returns>The <c>Hours</c> values if it is valid.</returns>
    /// <exception cref="InvalidValueException">If the <c>Hours</c> value is not valid.</exception>
    private int ValidateHours(int hours) {
        if (hours < 0) {
            throw new InvalidValueException("Invalid appointment time hours value.", "value < 0");
        } else if (hours > 24) {
            throw new InvalidValueException("Invalid appointment time hours value.", "value > 24");
        }
        return hours;
    }

    /// <summary>
    /// Validates a <c>Minutes</c> value for a <see cref="AppointmentTimeDTO.Minutes"/> instance.
    /// Returns the passed value to check if it is valid. Throws exceptions otherwise.
    /// </summary>
    /// <param name="minutes">The <c>Minutes</c> value to validate.</param>
    /// <returns>The <c>Minutes</c> values if it is valid.</returns>
    /// <exception cref="InvalidValueException">If the <c>Minutes</c> value is not valid.</exception>
    private int ValidateMinutes(int minutes) {
        if (minutes < 0) {
            throw new InvalidValueException("Invalid appointment time minutes value.", "value < 0");
        } else if (minutes > 59) {
            throw new InvalidValueException("Invalid appointment time minutes value.", "value > 59");
        }
        return minutes;
    }
}
