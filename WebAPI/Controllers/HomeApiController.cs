using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeApiController : ControllerBase
{
    private readonly IAuthService _authService;

    public HomeApiController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("index")]
    public IActionResult Index()
    {
        var token = Request.Cookies["JwtToken"];
        if (token != null)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var nameClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;

                if (nameClaim != null)
                {
                    return Ok(new { IsLoggedIn = true, Username = nameClaim });
                }
                else
                {
                    return Ok(new { IsLoggedIn = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Token Error: {ex.Message}" });
            }
        }
        else
        {
            return Ok(new { IsLoggedIn = false });
        }
    }
    

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("JwtToken");
        return Ok(new { message = "Logged out successfully" });
    }
}