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

    public async Task<IActionResult> Index()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return View(contacts);
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
            TempData["SuccessMessage"] = "Tạo contact thành công!";
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }
}