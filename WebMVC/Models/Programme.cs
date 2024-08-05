using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVC.Models;

public class Programme
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ContactId { get; set; }
    public bool IsActive { get; set; }

    public Contact Contact { get; set; } // Navigation property
}

public class CreateProgrammeDto
{
    [Required] public string Name { get; set; }
    public string Description { get; set; }
    [Required] public int ContactId { get; set; }
    public bool IsActive { get; set; } = true;
}

public class UpdateProgrammeDto
{
    public int Id { get; set; } 

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int ContactId { get; set; }

    public bool IsActive { get; set; }
}