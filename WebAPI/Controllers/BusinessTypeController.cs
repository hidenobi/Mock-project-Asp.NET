
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessTypeController : ControllerBase
{
    private readonly IBusinessTypeService _businessTypeService;

    public BusinessTypeController(IBusinessTypeService businessTypeService)
    {
        _businessTypeService = businessTypeService;
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<BusinessType>> Search([FromQuery] string businessName, [FromQuery] string sicCode = "")
    {
        var results = _businessTypeService.SearchBusinessTypes(businessName, sicCode);
        return Ok(results);
    }
}