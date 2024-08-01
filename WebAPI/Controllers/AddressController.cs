using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<AddressSearchResult>> Search(
        [FromQuery] string postcode = "", 
        [FromQuery] string street = "", 
        [FromQuery] string town = "")
    {
        var results = _addressService.SearchAddresses(postcode, street, town);
        return Ok(results);
    }
}
