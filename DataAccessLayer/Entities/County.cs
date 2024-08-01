using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class County
{
    [Key]
    public int CountyID { get; set; }

    [ForeignKey("Country")]
    public int CountryID { get; set; }

    [Required]
    public string? CountyName { get; set; }

    public virtual Country? Country { get; set; }
    public virtual ICollection<Town>? Towns { get; set; }
}