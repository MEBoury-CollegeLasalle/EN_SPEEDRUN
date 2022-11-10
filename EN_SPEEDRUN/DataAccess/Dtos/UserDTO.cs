﻿using EN_SPEEDRUN.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Users")]
public class UserDTO : IDto {

    [Key]
    public int Id { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int ClinicId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Precision(6)]
    public DateTime LastLogin { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }



    [ForeignKey("ClinicId")]
    public ClinicDTO Clinic { get; set; }

    [ForeignKey("StatusId")]
    public StatusDTO Status { get; set; }

}