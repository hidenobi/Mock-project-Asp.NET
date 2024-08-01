using WebMVC.Models;

namespace WebMVC.Services;

public interface IAuthService
{
    Task<string> LoginAsync(LoginViewModel model);
    Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model);
}