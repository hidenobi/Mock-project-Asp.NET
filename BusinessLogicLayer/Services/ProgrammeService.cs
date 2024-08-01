using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class ProgrammeService : IProgrammeService
{
    private readonly IProgrammeRepository _programmeRepository;

    public ProgrammeService(IProgrammeRepository programmeRepository)
    {
        _programmeRepository = programmeRepository;
    }

    public async Task<IEnumerable<Programme>> GetAllProgrammesAsync()
    {
        return await _programmeRepository.GetAllProgrammesAsync();
    }

    public async Task<Programme> GetProgrammeByIdAsync(int id)
    {
        return await _programmeRepository.GetProgrammeByIdAsync(id);
    }

    public async Task AddProgrammeAsync(Programme programme)
    {
        await _programmeRepository.AddProgrammeAsync(programme);
    }

    public async Task UpdateProgrammeAsync(Programme programme)
    {
        await _programmeRepository.UpdateProgrammeAsync(programme);
    }

    public async Task DeleteProgrammeAsync(int id)
    {
        await _programmeRepository.DeleteProgrammeAsync(id);
    }
}