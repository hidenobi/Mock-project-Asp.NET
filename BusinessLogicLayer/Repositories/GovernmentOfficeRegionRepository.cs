using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Repositories;

public class GovernmentOfficeRegionRepository : IGovernmentOfficeRegionRepository
{
    private readonly ApplicationDbContext _context;

    public GovernmentOfficeRegionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<GovernmentOfficeRegion>> GetAllGovernmentOfficeRegionsAsync()
    {
        return await _context.GovernmentOfficeRegions
            .Include(g => g.County)
            .ToListAsync();
    }

    public async Task<GovernmentOfficeRegion> GetGovernmentOfficeRegionByIdAsync(int id)
    {
        return await _context.GovernmentOfficeRegions
            .Include(g => g.County)
            .FirstOrDefaultAsync(g => g.GovernmentOfficeRegionId == id) ?? throw new InvalidOperationException();
    }
}