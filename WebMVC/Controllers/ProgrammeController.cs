using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;
using WebMVC.Services;
using Programme = WebMVC.Models.Programme;

namespace WebMVC.Controllers;
public class ProgrammeController : Controller
{
    private readonly IProgrammeService _programmeService;
    private readonly IContactService _contactService;

    public ProgrammeController(IProgrammeService programmeService, IContactService contactService)
    {
        _programmeService = programmeService;
        _contactService = contactService;
    }

    // GET: /Programme
    public async Task<IActionResult> Index()
    {
        var programmes = await _programmeService.GetAllProgrammesAsync();
        return View(programmes);
    }

    // GET: /Programme/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var programme = await _programmeService.GetProgrammeByIdAsync(id);
        if (programme == null)
        {
            return NotFound();
        }

        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");

        return View(programme);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateDetails(Programme programme)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var updateDto = new UpdateProgrammeDto
                {
                    Id = programme.Id,
                    Name = programme.Name,
                    Description = programme.Description,
                    ContactId = programme.ContactId,
                    IsActive = programme.IsActive
                };

                await _programmeService.UpdateProgrammeAsync(programme.Id, updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating programme: {ex.Message}");
            }
        }

        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");

        return View("Details", programme);
    }

    // GET: /Programme/Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");
        return View();
    }

    // POST: /Programme/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProgrammeDto dto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _programmeService.CreateProgrammeAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating programme: {ex.Message}");
            }
        }

        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");
        return View(dto);
    }

    // GET: /Programme/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var programme = await _programmeService.GetProgrammeByIdAsync(id);
        if (programme == null)
        {
            return NotFound();
        }

        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");

        var dto = new UpdateProgrammeDto
        {
            Id = programme.Id,
            Name = programme.Name,
            Description = programme.Description,
            ContactId = programme.ContactId,
            IsActive = programme.IsActive
        };

        return View(dto);
    }

    // POST: /Programme/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateProgrammeDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _programmeService.UpdateProgrammeAsync(dto.Id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating programme: {ex.Message}");
            }
        }

        var contacts = await _contactService.GetAllContactsAsync();
        ViewBag.Contacts = new SelectList(contacts, "Id", "Firstname");

        return View(dto);
    }

    // GET: /Programme/Delete/5
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var programme = await _programmeService.GetProgrammeByIdAsync(id);
        if (programme == null)
        {
            return NotFound();
        }
        return View(programme);
    }

    // POST: /Programme/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _programmeService.DeleteProgrammeAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error deleting programme: {ex.Message}");
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}