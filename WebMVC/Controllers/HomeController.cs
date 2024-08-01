using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApiService _apiService;

    public HomeController( ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        var isLoggedIn = Request.Cookies["JwtToken"] != null;
        ViewData["IsLoggedIn"] = isLoggedIn;

        if (isLoggedIn)
        {
            ViewData["Username"] = Request.Cookies["Username"]; // Lấy tên người dùng từ cookie
        }

        return View();
    }
    
    
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var token = await _apiService.LoginAsync(model);

        if (token == null)
        {
            ViewData["ErrorMessage"] = "Invalid username or password";
            return View();
        }

        Response.Cookies.Append("JwtToken", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true, // Chỉ đặt thành true nếu sử dụng HTTPS
            SameSite = SameSiteMode.Strict
        });

        // Lưu trữ tên người dùng vào cookie hoặc một cách khác để truy cập sau này
        Response.Cookies.Append("Username", model.Username, new CookieOptions
        {
            HttpOnly = true,
            Secure = true, // Chỉ đặt thành true nếu sử dụng HTTPS
            SameSite = SameSiteMode.Strict
        });

        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        var result = await _apiService.ForgotPasswordAsync(model);

        if (result)
        {
            ViewData["SuccessMessage"] = "Password has been sent to your email";
        }
        else
        {
            ViewData["ErrorMessage"] = "Failed to retrieve password. Please check your username and email.";
        }

        return View();
    }

    [HttpPost]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("JwtToken");
        return RedirectToAction("Index");
    }
    
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}