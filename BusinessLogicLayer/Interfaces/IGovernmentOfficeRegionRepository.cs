using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IGovernmentOfficeRegionRepository
{
    Task<IEnumerable<GovernmentOfficeRegion>> GetAllGovernmentOfficeRegionsAsync();
    Task<GovernmentOfficeRegion> GetGovernmentOfficeRegionByIdAsync(int id);
}