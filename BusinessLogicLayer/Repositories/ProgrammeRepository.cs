using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Repositories;

public class ProgrammeRepository : IProgrammeRepository
{
    private readonly ApplicationDbContext _context;

    public ProgrammeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Programme>> GetAllProgrammesAsync()
    {
        return await _context.Programmes.ToListAsync();
    }

    public async Task<Programme> GetProgrammeByIdAsync(int id)
    {
        return await _context.Programmes.FindAsync(id);
    }

    public async Task AddProgrammeAsync(Programme programme)
    {
        _context.Programmes.Add(programme);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProgrammeAsync(Programme programme)
    {
        _context.Entry(programme).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProgrammeAsync(int id)
    {
        var programme = await _context.Programmes.FindAsync(id);
        if (programme != null)
        {
            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();
        }
    }
}