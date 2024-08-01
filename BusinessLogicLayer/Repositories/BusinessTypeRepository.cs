using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Repositories;

public class BusinessTypeRepository : IBusinessTypeRepository
{
    private readonly ApplicationDbContext _context;

    public BusinessTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BusinessType> Search(string businessName, string sicCode)
    {
        var query = _context.BusinessTypes.AsQueryable();
        if (!string.IsNullOrWhiteSpace(businessName))
            {
                query = query.Where(b => b.BusinessName != null && b.BusinessName.Contains(businessName)).OrderBy(b => b.BusinessName);
            }

        if (!string.IsNullOrWhiteSpace(sicCode))
        {
            query = query.Where(b => b.SICCode != null && b.SICCode.Contains(sicCode)).OrderBy(b => b.BusinessName);
        }
        

        return query.ToList();
    }
}