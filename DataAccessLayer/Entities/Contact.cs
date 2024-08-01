using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required] public string? Firstname { get; set; }

    [Required] public string? Surname { get; set; }

    public string? KnownAs { get; set; }
    public string? OfficePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? StHomePhone { get; set; }

    [EmailAddress] public string? EmailAddress { get; set; }

    public ManagerName? ManagerName { get; set; }
    public int ManagerNameId { get; set; }

    [Required] public string? ContactType { get; set; }

    public string? BestContactMethod { get; set; }
    public string? JobRole { get; set; }
    public string? Workbase { get; set; }
    public string? JobTitle { get; set; }

    public bool IsActive { get; set; }
}