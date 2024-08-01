using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IGovernmentOfficeRegionService
{
    Task<IEnumerable<GovernmentOfficeRegion>> GetAllGovernmentOfficeRegionsAsync();
    Task<GovernmentOfficeRegion> GetGovernmentOfficeRegionByIdAsync(int id);
}