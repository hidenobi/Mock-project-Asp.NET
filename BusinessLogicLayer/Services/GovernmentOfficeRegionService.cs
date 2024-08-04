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
        // IEnumerable<GovernmentOfficeRegion> govs = await _repository.GetAllGovernmentOfficeRegionsAsync();
        // return govs.Select(g => new GovernmentOfficeRegion
        // {
        //     GovernmentOfficeRegionName = g.GovernmentOfficeRegionName,
        //     Description = g.Description,
        //     County = g.County,
        //     IsActive = g.IsActive
        // });
        
        return await _repository.GetAllGovernmentOfficeRegionsAsync();
    }

    public async Task<GovernmentOfficeRegion> GetGovernmentOfficeRegionByIdAsync(int id)
    {
        // var gov = await _repository.GetGovernmentOfficeRegionByIdAsync(id);
        //
        // return new GovernmentOfficeRegion
        // {
        //     GovernmentOfficeRegionName = gov.GovernmentOfficeRegionName,
        //     Description = gov.Description,
        //     County = gov.County,
        //     IsActive = gov.IsActive
        // };
        
        return await _repository.GetGovernmentOfficeRegionByIdAsync(id);
    }
}