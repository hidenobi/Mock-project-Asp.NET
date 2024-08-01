using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class Country
{
    [Key]
    public int CountryID { get; set; }

    [Required]
    public string? CountryName { get; set; }

    public virtual ICollection<County>? Counties { get; set; }
}