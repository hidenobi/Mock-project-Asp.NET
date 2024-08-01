using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class ForgotPasswordViewModel
{
    [Required]
    [StringLength(50)]
    public string? Username { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string? Email { get; set; }
}