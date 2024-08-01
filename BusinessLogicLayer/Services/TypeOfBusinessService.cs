using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Services
{
    public class TypeOfBusinessService
    {
        private readonly ApplicationDbContext _context;

        public TypeOfBusinessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(List<TypeOfBusiness> Items, int TotalPages)> SearchBusinessesAsync(string? businessName, string? sicCode, int page, int pageSize)
        {
            var query = _context.Businesses.AsQueryable().OrderBy(b => b.BusinessName);

            if (!string.IsNullOrWhiteSpace(businessName))
            {
                query = query.Where(b => b.BusinessName != null && b.BusinessName.Contains(businessName)).OrderBy(b => b.BusinessName);
            }

            if (!string.IsNullOrWhiteSpace(sicCode))
            {
                query = query.Where(b => b.SicCode != null && b.SicCode.Contains(sicCode)).OrderBy(b => b.BusinessName);
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var businesses = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (businesses, totalPages);
        }

    }

}
