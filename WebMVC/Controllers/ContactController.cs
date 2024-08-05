using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // public async Task<IActionResult> Index()
    // {
    //     var contacts = await _contactService.GetAllContactsAsync();
    //     return View(contacts);
    // }

    [HttpGet]
    public async Task<IActionResult> Index(
        string? firstNameSearch,
        string? surnameSearch,
        bool? isActiveFilter,
        int page = 1
    )
    {
        int pageSize = 4;
        var pagedResult =
            await _contactService.GetAllContactsByFirstNameAndSurnameAndIsActive
            (
                firstNameSearch,
                surnameSearch,
                isActiveFilter,
                page, 
                pageSize
            );
        ViewBag.FirstNameSearch = firstNameSearch;
        ViewBag.SurnameSearch = surnameSearch;
        ViewBag.IsActiveFilter = isActiveFilter ?? true;
        return View(pagedResult);
    }

    public async Task<IActionResult> Details(int id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);
        return View(contact);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        Console.WriteLine($"TAG-PT: for view create");
        var managerNames = await _contactService.GetAllManagerNamesAsync();
        ViewBag.ManagerNames = new SelectList(managerNames, "Id", "Name", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactDto contact)
    {
        Console.WriteLine($"TAG-PT: for action create");
        if (ModelState.IsValid)
        {
            await _contactService.CreateContactAsync(contact);
            return RedirectToAction(nameof(Index));
        }

        return View(contact);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        Console.WriteLine($"TAG-PT: for view edit");
        var contact = await _contactService.GetContactByIdAsync(id);
        var managerNames = await _contactService.GetAllManagerNamesAsync();
        ViewBag.ManagerNames = new SelectList(managerNames, "Id", "Name", "Name");
        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ContactDto contactDto)
    {
        var id = contactDto.Id;
        var updateContactDto = ContactConverter.ToUpdateContactDto(contactDto);
        Console.WriteLine($"TAG-PT: for action edit {id}");
        try
        {
            var updatedContact = await _contactService.UpdateContactAsync(id, updateContactDto);
            if (updatedContact == null)
            {
                // Log lỗi không tìm thấy contact hoặc lỗi cập nhật
                Console.WriteLine($"Failed to update contact with id {id}");
                return NotFound($"Contact with id {id} not found or could not be updated");
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            // Log lỗi
            Console.WriteLine($"Error updating contact: {ex.Message}");
            ModelState.AddModelError("", "An error occurred while updating the contact. Please try again.");
            return RedirectToAction(nameof(Index));
        }
    }
}