using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GovernmentOfficeRegionController : ControllerBase
{
    private readonly IGovernmentOfficeRegionService _service;

    public GovernmentOfficeRegionController(IGovernmentOfficeRegionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GovernmentOfficeRegion>>> GetAllGovernmentOfficeRegion()
    {
        IEnumerable<GovernmentOfficeRegion> govs = await _service.GetAllGovernmentOfficeRegionsAsync();
        return Ok(govs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GovernmentOfficeRegion>> GetGovernmentOfficeRegionById(int id)
    {
        GovernmentOfficeRegion gov = await _service.GetGovernmentOfficeRegionByIdAsync(id);
        return Ok(gov);
    }
}