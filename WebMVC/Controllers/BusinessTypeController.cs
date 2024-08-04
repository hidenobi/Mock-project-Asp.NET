using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using DataAccessLayer.Entities;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    public class BusinessTypeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BusinessTypeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            return View(new PagedResult<BusinessType>());
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string businessName, string sicCode, int page = 1)
        {
            businessName = businessName ?? string.Empty;
            sicCode = sicCode ?? string.Empty;

            var client = _clientFactory.CreateClient("BusinessTypeAPI");
            
            var response = await client.GetAsync($"api/businesstype/search?businessName={Uri.EscapeDataString(businessName)}&sicCode={Uri.EscapeDataString(sicCode)}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonSerializer.Deserialize<List<BusinessType>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                int pageSize = 5;  // Set page size to 5
                if(results == null){
                    throw new InvalidOperationException("No results found.");
                }
                int totalItems = results.Count;
                var itemsOnPage = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var pagedResult = new PagedResult<BusinessType>
                {
                    Items = itemsOnPage,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                return PartialView("_BusinessTypeSearchResults", pagedResult);
            }

            return PartialView("_BusinessTypeSearchResults", new PagedResult<BusinessType>());
        }
    }
}
