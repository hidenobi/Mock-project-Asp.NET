using WebMVC.Models;

namespace WebMVC.Services;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;
    private readonly string? _baseUrl;

    public ContactService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ApiSettings:BaseUrl"];
    }

    public async Task<IEnumerable<ContactDto?>> GetAllContactsAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}contacts");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<ContactDto>>();
    }

    public async Task<IEnumerable<ContactDto?>> GetAllContactsByFirstNameAndSurnameAndIsActive
    (
        string? firstName,
        string? surname,
        bool? isActive
    )
    {
        Console.WriteLine($"TAG-PT: {firstName} {surname} {isActive}");
        var response =
            await _httpClient.GetAsync(
                $"{_baseUrl}contacts/search?firstName={firstName}&surname={surname}&isActive={isActive}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<ContactDto>>();
    }

    public async Task<ContactDto> GetContactByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}contacts/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ContactDto>();
    }

    public async Task<CreateContactDto?> CreateContactAsync(CreateContactDto createContactDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}contacts", createContactDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CreateContactDto>();
    }

    public async Task<UpdateContactDto?> UpdateContactAsync(int id, UpdateContactDto updateContactDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}contacts/{id}", updateContactDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UpdateContactDto>();
    }

    public async Task<IEnumerable<ManagerName>?> GetAllManagerNamesAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}contacts/manager_names");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<ManagerName>>();
    }
}