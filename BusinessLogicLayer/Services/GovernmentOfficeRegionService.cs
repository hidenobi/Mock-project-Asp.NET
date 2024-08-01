using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class GovernmentOfficeRegionService : IGovernmentOfficeRegionService
{
    private readonly IGovernmentOfficeRegionRepository _repository;

    public GovernmentOfficeRegionService(IGovernmentOfficeRegionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<GovernmentOfficeRegion>> GetAllGovernmentOfficeRegionsAsync()
    {
        return await _repository.GetAllGovernmentOfficeRegionsAsync();
    }

    public async Task<GovernmentOfficeRegion> GetGovernmentOfficeRegionByIdAsync(int id)
    {
        return await _repository.GetGovernmentOfficeRegionByIdAsync(id);
    }
}