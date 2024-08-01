using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities.Dto;

public class ContactDto : Contact
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string? KnownAs { get; set; }
    public string? OfficePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? StHomePhone { get; set; }
    public string? EmailAddress { get; set; }
    public int ManagerNameId { get; set; }
    public string? ManagerName { get; set; } // Chỉ tên của Manager
    public string? ContactType { get; set; }
    public string? BestContactMethod { get; set; }
    public string? JobRole { get; set; }
    public string? Workbase { get; set; }
    public string? JobTitle { get; set; }
    public bool IsActive { get; set; }
}

public class CreateContactDto 
{
    [Required] public string? Firstname { get; set; }

    [Required] public string? Surname { get; set; }

    public string? KnownAs { get; set; }
    public string? OfficePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? StHomePhone { get; set; }

    [EmailAddress] public string? EmailAddress { get; set; }

    public int ManagerNameId { get; set; }

    [Required] public string? ContactType { get; set; }

    public string? BestContactMethod { get; set; }
    public string? JobRole { get; set; }
    public string? Workbase { get; set; }
    public string? JobTitle { get; set; }

    public bool IsActive { get; set; } = true; // Mặc định là true khi tạo mới
}

public class UpdateContactDto 
{
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string? KnownAs { get; set; }
    public string? OfficePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? StHomePhone { get; set; }
    public string? EmailAddress { get; set; }
    public int ManagerNameId { get; set; }
    public string? ContactType { get; set; }
    public string? BestContactMethod { get; set; }
    public string? JobRole { get; set; }
    public string? Workbase { get; set; }
    public string? JobTitle { get; set; }
    public bool IsActive { get; set; }
}

public class ManagerNameDto 
{
    public int Id { get; set; }
    public string? Name { get; set; }
}