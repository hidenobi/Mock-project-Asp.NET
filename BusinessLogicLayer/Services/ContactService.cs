using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class ContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<Contact>> GetAllContacts()
    {
        return await _contactRepository.GetAllContacts();
    }

    public async Task<Contact?> GetContactById(int id)
    {
        return await _contactRepository.GetContactById(id);
    }

    public async Task AddContact(Contact contact)
    {
        await _contactRepository.AddContact(contact);
    }

    public async Task UpdateContact(Contact contact)
    {
        await _contactRepository.UpdateContact(contact);
    }
}