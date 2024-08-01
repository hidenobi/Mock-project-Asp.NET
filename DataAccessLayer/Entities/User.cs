using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [Required]
    [StringLength(50)]
    public string Role { get; set; }  // "customer" or "admin"
 
    [Required]
    [StringLength(50)]
    public string Email { get; set; }
}