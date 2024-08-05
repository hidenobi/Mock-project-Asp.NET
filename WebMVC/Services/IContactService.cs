using WebMVC.Models;

namespace WebMVC.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDto?>> GetAllContactsAsync();

    Task<Pagination.PagedResult<ContactDto?>> GetAllContactsByFirstNameAndSurnameAndIsActive
    (
        string? firstName,
        string? surname,
        bool? isActive,
        int page = 1,
        int pageSize = 4
    );

    Task<ContactDto> GetContactByIdAsync(int id);
    Task<CreateContactDto?> CreateContactAsync(CreateContactDto createContactDto);
    Task<UpdateContactDto?> UpdateContactAsync(int id, UpdateContactDto updateContactDto);

    Task<IEnumerable<ManagerName>?> GetAllManagerNamesAsync();
}