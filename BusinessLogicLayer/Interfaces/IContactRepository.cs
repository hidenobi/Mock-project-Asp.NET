using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContacts();
    Task<Contact?> GetContactById(int id);
    Task AddContact(Contact contact);
    Task UpdateContact(Contact contact);

}