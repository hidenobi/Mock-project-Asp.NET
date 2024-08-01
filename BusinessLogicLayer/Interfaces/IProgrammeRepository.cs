using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IProgrammeRepository
{
    Task<IEnumerable<Programme>> GetAllProgrammesAsync();
    Task<Programme> GetProgrammeByIdAsync(int id);
    Task AddProgrammeAsync(Programme programme);
    Task UpdateProgrammeAsync(Programme programme);
    Task DeleteProgrammeAsync(int id);
}