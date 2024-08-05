using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class ProgrammeRepository : IProgrammeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgrammeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programme>> GetAllProgrammesAsync()
        {
            return await _context.Programmes
                .Include(p => p.Contact)
                .ToListAsync();
        }

        public async Task<Programme> GetProgrammeByIdAsync(int id)
        {
            return await _context.Programmes
                .Include(p => p.Contact)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProgrammeAsync(Programme programme)
        {
            var existingProgramme = await _context.Programmes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == programme.Id);

            if (existingProgramme != null)
            {
                throw new Exception("Programme already exists");
            }

            _context.Programmes.Add(programme);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgrammeAsync(Programme programme)
        {
            var existingProgramme = await _context.Programmes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == programme.Id);

            if (existingProgramme == null)
            {
                throw new Exception("Programme not found");
            }

            _context.Entry(existingProgramme).CurrentValues.SetValues(programme);
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
}