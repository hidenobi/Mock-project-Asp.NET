using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllContacts()
    {
        var contacts = await _context.Contacts
            .Include(c => c.ManagerName)
            .Select(c => new ContactDto
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Surname = c.Surname,
                KnownAs = c.KnownAs,
                OfficePhone = c.OfficePhone,
                MobilePhone = c.MobilePhone,
                StHomePhone = c.StHomePhone,
                EmailAddress = c.EmailAddress,
                ManagerNameId = c.ManagerNameId,
                ManagerName = c.ManagerName.Name, // Lấy tên của ManagerName
                ContactType = c.ContactType,
                BestContactMethod = c.BestContactMethod,
                JobRole = c.JobRole,
                Workbase = c.Workbase,
                JobTitle = c.JobTitle,
                IsActive = c.IsActive,
            })
            .ToListAsync();

        return contacts;
    }

    public async Task<PagedResult<ContactDto>> GetAllContactsByFirstNameAndSurnameAndIsActive
    (
        string? firstName,
        string? surname,
        bool? isActive,
        int page = 1,
        int pageSize = 4
    )
    {
        var query = _context.Contacts.AsQueryable();
        if (!firstName.IsNullOrEmpty())
        {
            query = query.Where(c => c.Firstname != null && c.Firstname.Equals(firstName));
        }

        if (!surname.IsNullOrEmpty())
        {
            query = query.Where(c => c.Surname != null && c.Surname.Equals(surname));
        }

        if (isActive.HasValue)
        {
            query = query.Where(c => c.IsActive == isActive);
        }

        var contacts = await query
            .Include(c => c.ManagerName)
            .Select(c => new ContactDto
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Surname = c.Surname,
                KnownAs = c.KnownAs,
                OfficePhone = c.OfficePhone,
                MobilePhone = c.MobilePhone,
                StHomePhone = c.StHomePhone,
                EmailAddress = c.EmailAddress,
                ManagerNameId = c.ManagerNameId,
                ManagerName = c.ManagerName.Name, // Lấy tên của ManagerName
                ContactType = c.ContactType,
                BestContactMethod = c.BestContactMethod,
                JobRole = c.JobRole,
                Workbase = c.Workbase,
                JobTitle = c.JobTitle,
                IsActive = c.IsActive,
            })
            .ToListAsync();

        return new PagedResult<ContactDto>
        {
            Items = contacts,
            TotalItems = contacts.Count,
            PageNumber = page,
            PageSize = pageSize,
        };
    }

    public async Task<Contact?> GetContactById(int id)
    {
        var contact = _context.Contacts
            .Where(c => c.Id == id)
            .Include(c => c.ManagerName)
            .Select(c => new ContactDto
            {
                Id = c.Id,
                Firstname = c.Firstname,
                Surname = c.Surname,
                KnownAs = c.KnownAs,
                OfficePhone = c.OfficePhone,
                MobilePhone = c.MobilePhone,
                StHomePhone = c.StHomePhone,
                EmailAddress = c.EmailAddress,
                ManagerNameId = c.ManagerNameId,
                ManagerName = c.ManagerName.Name, // Lấy tên của ManagerName
                ContactType = c.ContactType,
                BestContactMethod = c.BestContactMethod,
                JobRole = c.JobRole,
                Workbase = c.Workbase,
                JobTitle = c.JobTitle,
                IsActive = c.IsActive,
            }).FirstOrDefault();

        return contact;
    }

    public async Task AddContact(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }
}