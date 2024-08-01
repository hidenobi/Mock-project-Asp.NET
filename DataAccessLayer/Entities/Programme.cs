using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;
public class Programme
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int ContactId { get; set; }

    public bool IsActive { get; set; }

    public Contact Contact { get; set; }
}