
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly TypeOfBusinessService _businessService;

        public BusinessController(TypeOfBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? businessName, string? sicCode, int page = 1)
        {
            int pageSize = 15;

            var (businesses, totalPages) = await _businessService.SearchBusinessesAsync(businessName, sicCode, page, pageSize);

            return Ok(new
            {
                items = businesses,
                totalPagesResult = totalPages
            });
        }
    }
    
}