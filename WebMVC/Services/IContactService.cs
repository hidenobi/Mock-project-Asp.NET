using WebMVC.Models;

namespace WebMVC.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDto?>> GetAllContactsAsync();

    Task<IEnumerable<ContactDto?>> GetAllContactsByFirstNameAndSurnameAndIsActive
    (
        string? firstName,
        string? surname,
        bool? isActive
    );

    Task<ContactDto> GetContactByIdAsync(int id);
    Task<CreateContactDto?> CreateContactAsync(CreateContactDto createContactDto);
    Task<UpdateContactDto?> UpdateContactAsync(int id, UpdateContactDto updateContactDto);

    Task<IEnumerable<ManagerName>?> GetAllManagerNamesAsync();
}