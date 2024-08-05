using WebMVC.Models;

namespace WebMVC.Services;

public interface IProgrammeService
{
    Task<IEnumerable<Programme>> GetAllProgrammesAsync();
    Task<Programme> GetProgrammeByIdAsync(int id);
    Task<Programme> CreateProgrammeAsync(CreateProgrammeDto dto);
    Task<Programme> UpdateProgrammeAsync(int id, UpdateProgrammeDto dto);
    Task DeleteProgrammeAsync(int id);
    Task<IEnumerable<Contact>> GetAllContactsAsync();
}