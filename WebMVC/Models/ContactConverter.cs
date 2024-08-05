namespace WebMVC.Models;

public static class ContactConverter
{
    public static UpdateContactDto ToUpdateContactDto(ContactDto contactDto)
    {
        return new UpdateContactDto
        {
            Firstname = contactDto.Firstname,
            Surname = contactDto.Surname,
            KnownAs = contactDto.KnownAs,
            OfficePhone = contactDto.OfficePhone,
            MobilePhone = contactDto.MobilePhone,
            StHomePhone = contactDto.StHomePhone,
            EmailAddress = contactDto.EmailAddress,
            ManagerNameId = contactDto.ManagerNameId,
            ContactType = contactDto.ContactType,
            BestContactMethod = contactDto.BestContactMethod,
            JobRole = contactDto.JobRole,
            Workbase = contactDto.Workbase,
            JobTitle = contactDto.JobTitle,
            IsActive = contactDto.IsActive
        };
    }
}