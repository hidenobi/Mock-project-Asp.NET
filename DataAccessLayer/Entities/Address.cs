using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Address
{
    [Key]
    public int AddressID { get; set; }

    [Required]
    public string? AddressName { get; set; }

    [Required]
    public string? PostCode { get; set; }

    [ForeignKey("Town")]
    public int TownID { get; set; }

    public virtual Town? Town { get; set; }
}