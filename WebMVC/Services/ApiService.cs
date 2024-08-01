using RestSharp;
using WebMVC.Models;

namespace WebMVC.Services;

public class ApiService
{
    private readonly RestClient _client;

    public ApiService()
    {
        _client = new RestClient("http://localhost:5019");
    }

    public async Task<string> LoginAsync(LoginViewModel model)
    {
        var request = new RestRequest("api/AuthApi/login", Method.Post);
        request.AddJsonBody(model);

        var response = await _client.ExecuteAsync<LoginResponse>(request);

        if (response.IsSuccessful && response.Data != null)
        {
            return response.Data.Token;
        }
        return null;
    }

    public async Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model)
    {
        var request = new RestRequest("api/AuthApi/forgotpassword", Method.Post);
        request.AddJsonBody(model);

        var response = await _client.ExecuteAsync(request);
        return response.IsSuccessful;
    }
}

public class LoginResponse
{
    public string Token { get; set; }
}