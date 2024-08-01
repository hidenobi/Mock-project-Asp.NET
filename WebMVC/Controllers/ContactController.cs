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
    //
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var managerNames = await _contactService.GetAllManagerNamesAsync();
        ViewBag.ManagerNames = new SelectList(managerNames);
        return View();
    }
    //
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactDto contact)
    {
       
            await _contactService.CreateContactAsync(contact);
       
        var managerNames = await _contactService.GetAllManagerNamesAsync();
        ViewBag.ManagerNames = new SelectList(managerNames);
        return View(contact);
    }

    
}