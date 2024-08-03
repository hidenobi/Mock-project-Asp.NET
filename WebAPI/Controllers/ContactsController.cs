using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ContactService _contactService;
    private readonly ManagerNameService _managerNameService;

    public ContactsController(ContactService contactService, ManagerNameService managerNameService)
    {
        _contactService = contactService;
        _managerNameService = managerNameService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
    {
        return Ok(await _contactService.GetAllContacts());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactById(int id)
    {
        var contact = await _contactService.GetContactById(id);
        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult> AddContact([FromBody] CreateContactDto createContactDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managerName = await _managerNameService.GetManagerNameById(createContactDto.ManagerNameId);
        var managerExists = managerName != null;
        if (!managerExists)
        {
            return BadRequest("Invalid ManagerNameId");
        }

        var contact = new Contact
        {
            Firstname = createContactDto.Firstname,
            Surname = createContactDto.Surname,
            KnownAs = createContactDto.KnownAs,
            OfficePhone = createContactDto.OfficePhone,
            MobilePhone = createContactDto.MobilePhone,
            StHomePhone = createContactDto.StHomePhone,
            EmailAddress = createContactDto.EmailAddress,
            ManagerNameId = createContactDto.ManagerNameId,
            ContactType = createContactDto.ContactType,
            BestContactMethod = createContactDto.BestContactMethod,
            JobRole = createContactDto.JobRole,
            Workbase = createContactDto.Workbase,
            JobTitle = createContactDto.JobTitle,
            IsActive = createContactDto.IsActive,
        };

        await _contactService.AddContact(contact);
        var contactDto = new ContactDto
        {
            Id = contact.Id,
            Firstname = contact.Firstname,
            Surname = contact.Surname,
            KnownAs = contact.KnownAs,
            OfficePhone = contact.OfficePhone,
            MobilePhone = contact.MobilePhone,
            StHomePhone = contact.StHomePhone,
            EmailAddress = contact.EmailAddress,
            ManagerNameId = contact.ManagerNameId,
            ManagerName = managerName!.Name,
            ContactType = contact.ContactType,
            BestContactMethod = contact.BestContactMethod,
            JobRole = contact.JobRole,
            Workbase = contact.Workbase,
            JobTitle = contact.JobTitle,
            IsActive = contact.IsActive
        };

        return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contactDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactDto updateContactDto)
    {
        var mContact = await _contactService.GetContactById(id);
        if (mContact == null)
        {
            return NotFound($"Contact with ID {id} not found.");
        }
        else
        {
            var contact = mContact;
            if (updateContactDto.ManagerNameId != contact.ManagerNameId)
            {
                var managerName = await _managerNameService.GetManagerNameById(updateContactDto.ManagerNameId);
                var managerExists = managerName != null;
                if (!managerExists)
                {
                    return BadRequest("Invalid ManagerNameId");
                }
            }


            // Cập nhật thông tin contact
            contact.Firstname = updateContactDto.Firstname;
            contact.Surname = updateContactDto.Surname;
            contact.KnownAs = updateContactDto.KnownAs;
            contact.OfficePhone = updateContactDto.OfficePhone;
            contact.MobilePhone = updateContactDto.MobilePhone;
            contact.StHomePhone = updateContactDto.StHomePhone;
            contact.EmailAddress = updateContactDto.EmailAddress;
            contact.ManagerNameId = updateContactDto.ManagerNameId;
            contact.ContactType = updateContactDto.ContactType;
            contact.BestContactMethod = updateContactDto.BestContactMethod;
            contact.JobRole = updateContactDto.JobRole;
            contact.Workbase = updateContactDto.Workbase;
            contact.JobTitle = updateContactDto.JobTitle;
            contact.IsActive = updateContactDto.IsActive;
            await _contactService.UpdateContact(contact);
            return NoContent();
        }
    }
}