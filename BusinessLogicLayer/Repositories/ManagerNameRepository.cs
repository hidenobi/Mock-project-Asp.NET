using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Repositories;

public class ManagerNameRepository : IManagerNameRepository
{
    private readonly ApplicationDbContext _context;

    public ManagerNameRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ManagerName>> GetAllManagerName()
    {
        return await _context.ManagerNames.ToListAsync();
    }

    public async Task<ManagerName?> GetManagerNameById(int id)
    {
        return await _context.ManagerNames.FindAsync(id);
    }
}