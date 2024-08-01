using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class BusinessType
{
    [Key]
    public int BussinessID { get; set; }
    [Required]
    public string? BusinessName { get; set; }
    [Required]
    [RegularExpression(@"^\d{4}$")]

    public string? SICCode { get; set; }
}