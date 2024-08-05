using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

//[Route("[controller]")]
public class GovernmentOfficeRegionController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GovernmentOfficeRegionController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<IActionResult> Index(string filter = "All",bool includeInactive=false, int pageNumber = 1, int pageRecord = 15, string sortOrder = "name_asc")
    {
        var baseUrl = _configuration["MvcProject:applicationUrl"]
            ?.Split(";")
            .FirstOrDefault(url => url.StartsWith("http"));
        var apiUrl = $"{baseUrl}/api/GovernmentOfficeRegion";
        var response = await _httpClient.GetAsync(apiUrl);
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<GovernmentOfficeRegion>? govs = await response.Content.ReadFromJsonAsync<IEnumerable<GovernmentOfficeRegion>>();

            if (govs == null)
            {
                return NotFound();
            }
            
            if (!includeInactive)
            {
                govs = govs.Where(g => g.IsActive);
            }
            
            switch (filter)
            {
                case "0-9":
                    govs = govs.Where(g => char.IsDigit(g.GovernmentOfficeRegionName[0]));
                    break;
                case "A-E":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'A' && g.GovernmentOfficeRegionName[0] <= 'E');
                    break;
                case "F-J":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'F' && g.GovernmentOfficeRegionName[0] <= 'J');
                    break;
                case "K-N":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'K' && g.GovernmentOfficeRegionName[0] <= 'N');
                    break;
                case "O-R":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'O' && g.GovernmentOfficeRegionName[0] <= 'R');
                    break;
                case "S-V":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'S' && g.GovernmentOfficeRegionName[0] <= 'V');
                    break;
                case "W-Z":
                    govs = govs.Where(g =>
                            g.GovernmentOfficeRegionName[0] >= 'W' && g.GovernmentOfficeRegionName[0] <= 'Z');
                    break;
            }

            govs = sortOrder switch
            {
                "name_desc" => govs.OrderByDescending(g => g.GovernmentOfficeRegionName),
                "description_asc" => govs.OrderBy(g => g.Description),
                "description_desc" => govs.OrderByDescending(g => g.Description),
                "county_asc" => govs.OrderBy(g => g.County?.CountyName),
                "county_desc" => govs.OrderByDescending(g => g.County?.CountyName),
                "isActive_asc" => govs.OrderBy(g => g.IsActive),
                "isActive_desc" => govs.OrderByDescending(g => g.IsActive),
                _ => govs.OrderBy(g => g.GovernmentOfficeRegionName)
            };

            var governmentOfficeRegions = govs.ToList();
            var pageGovs = governmentOfficeRegions.Skip(((int)pageNumber - 1) * pageRecord).Take(pageRecord).ToList();
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageRecords = pageRecord;
            ViewBag.TotalPages = (int)Math.Ceiling(governmentOfficeRegions.Count() / (double)pageRecord);
            ViewBag.Filter = filter;
            ViewBag.IncludeInactive = includeInactive;
            ViewBag.SortOrder = sortOrder;
            return View(pageGovs);
        }
        
        return NotFound();
    }

    public async Task<IActionResult> Details(int id)
    {
        var baseUrl = _configuration["MvcProject:applicationUrl"]
            ?.Split(";")
            .FirstOrDefault(url => url.StartsWith("http"));
        var apiUrl = $"{baseUrl}/api/GovernmentOfficeRegion/{id}";
        var response = await _httpClient.GetAsync(apiUrl);
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