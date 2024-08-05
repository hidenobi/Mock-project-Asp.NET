using WebMVC.Models;
namespace WebMVC.Services;

public class ProgrammeService : IProgrammeService
{
    private readonly HttpClient _httpClient;
    private readonly IContactService _contactService;
    private readonly string? _baseUrl;

    public ProgrammeService(IConfiguration configuration, HttpClient httpClient, IContactService contactService)
    {
        _httpClient = httpClient;
        _contactService = contactService;
        _baseUrl = configuration["ApiSettings:BaseUrl"];
    }

    public async Task<IEnumerable<Programme>> GetAllProgrammesAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}programme");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Programme>>();
    }

    public async Task<Programme> GetProgrammeByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}programme/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Programme>();
    }

    public async Task<Programme> CreateProgrammeAsync(CreateProgrammeDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}programme", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Programme>();
    }

    public async Task<Programme> UpdateProgrammeAsync(int id, UpdateProgrammeDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}programme/{id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Programme>();
    }

    public async Task DeleteProgrammeAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}programme/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _contactService.GetAllContactsAsync();
    }
}