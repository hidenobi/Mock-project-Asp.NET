using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Dto;

namespace BusinessLogicLayer.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContacts();

    Task<PagedResult<ContactDto>> GetAllContactsByFirstNameAndSurnameAndIsActive(
        string? firstName,
        string? surname,
        bool? isActive,
        int page = 1,
        int pageSize = 4
    );

    Task<Contact?> GetContactById(int id);
    Task AddContact(Contact contact);
    Task UpdateContact(Contact contact);
}