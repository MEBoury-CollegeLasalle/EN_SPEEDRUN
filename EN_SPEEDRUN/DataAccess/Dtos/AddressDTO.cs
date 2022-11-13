using EN_SPEEDRUN.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Addresses")]
public class AddressDTO : IDto {

    [Key]
    public int Id { get; private set; }

    [Required]
    public int StreetNumber { get; set; }

    [Required]
    [StringLength(128)]
    public string Street { get; set; }

    [StringLength(32)]
    public string? StreetExtension { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    [StringLength(16)]
    public string PostalCode { get; set; }

    [Required]
    [StringLength(64)]
    public string Region { get; set; }

    [Required]
    [StringLength(64)]
    public string Country { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; private set; }

}
