using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContacts();

    Task<IEnumerable<Contact>> GetAllContactsByFirstNameAndSurnameAndIsActive(
        string? firstName,
        string? surname,
        bool? isActive
    );

    Task<Contact?> GetContactById(int id);
    Task AddContact(Contact contact);
    Task UpdateContact(Contact contact);
}