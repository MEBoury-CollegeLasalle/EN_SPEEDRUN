using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.DataAccess.Dtos;

[Table("Addresses")]
public class AddressDTO : IDTO {

    #region properties

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
    [StringLength(64)]
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

    #endregion


    public AddressDTO(
        int streetNumber, 
        string street, 
        string streetExtension, 
        string city, 
        string region, 
        string country, 
        string postalCode) { 

        // TODO: validation methods?
        this.StreetNumber = streetNumber;
        this.Street = street;
        this.StreetExtension = streetExtension;
        this.City = city;
        this.Region = region;
        this.Country = country;
        this.PostalCode = postalCode;
    }


    #region methods

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public int GetId() {
        return this.Id;
    }

    /// <summary>
    /// Generates a human readable string representing the values in the <see cref="AddressDTO"/> instance.
    /// </summary>
    /// <returns>A human readable string of the address.</returns>
    public string ToAddressString() {
        return this.StreetNumber + " "
            + this.Street
            + (this.StreetExtension == null ? "" : " " + this.StreetExtension)
            + ", " + this.City
            + ", " + this.Region
            + ", " + this.Country
            + ", " + this.PostalCode;

    }

    #endregion
}
