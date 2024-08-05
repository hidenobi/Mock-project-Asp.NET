using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DataAccessLayer.Entities;
public class Programme
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [ForeignKey("Contact")]
    public int ContactId { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("ContactId")]
    public Contact? Contact { get; set; }
}