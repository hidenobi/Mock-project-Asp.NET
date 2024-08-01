using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Town
{
    [Key]
    public int TownID { get; set; }

    [ForeignKey("County")]
    public int CountyID { get; set; }

    [Required]
    public string? TownName { get; set; }

    public virtual County? County { get; set; }
    public virtual ICollection<Address>? Addresses { get; set; }
}