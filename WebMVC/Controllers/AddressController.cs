using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Text.Json;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AddressController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            return View(new PagedResult<AddressSearchResult>());
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string postcode, string street, string town, int page = 1)
        {
            var client = _clientFactory.CreateClient("DefaultAPI");
            var response = await client.GetAsync($"address/search?postcode={postcode}&street={street}&town={town}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var results = JsonSerializer.Deserialize<List<AddressSearchResult>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                int pageSize = 15;  
                if(results == null){
                    throw new InvalidOperationException("No results found.");
                }
                int totalItems = results.Count;
                var itemsOnPage = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var pagedResult = new PagedResult<AddressSearchResult>
                {
                    Items = itemsOnPage,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                return PartialView("_SearchResults", pagedResult);
            }

            return PartialView("_SearchResults", new PagedResult<AddressSearchResult>());
        }
    }
}
