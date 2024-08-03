using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class ProgrammeController : Controller
{
    private readonly HttpClient _httpClient;

    public ProgrammeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        var programmes =
            await _httpClient.GetFromJsonAsync<IEnumerable<Programme>>("https://localhost:5168/api/programme");
        return View(programmes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var programme = await _httpClient.GetFromJsonAsync<Programme>($"https://localhost:5168/api/programme/{id}");
        if (programme == null)
        {
            return NotFound();
        }

        return View(programme);
    }
}