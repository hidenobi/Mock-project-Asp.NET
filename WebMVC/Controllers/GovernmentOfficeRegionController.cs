using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class GovernmentOfficeRegionController : Controller
{
    private readonly HttpClient _httpClient;

    public GovernmentOfficeRegionController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("https://localhost:5103/api/GovernmentOfficeRegion");
        if (response.IsSuccessStatusCode)
        {
            var govs = await response.Content.ReadFromJsonAsync<IEnumerable<GovernmentOfficeRegion>>();
            return View(govs);
        }

        
        return NotFound();
    }

    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetAsync($"https://localhost:5103/api/GovernmentOfficeRegion/{id}");
        if (response.IsSuccessStatusCode)
        {
            var gov = await response.Content.ReadFromJsonAsync<GovernmentOfficeRegion>();
            if (gov != null)
            {
                return View(gov);
            }
        }

        return NotFound();
    }
}