

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<AddressSearchResult> Search(string postcode, string street, string town)
    {
        var query = from a in _context.Addresses
                    join t in _context.Towns on a.TownID equals t.TownID
                    join c in _context.Counties on t.CountyID equals c.CountyID
                    join co in _context.Countries on c.CountryID equals co.CountryID
                    where (string.IsNullOrWhiteSpace(postcode) || (a.PostCode != null && a.PostCode.Contains(postcode)))
                        && (string.IsNullOrWhiteSpace(street) || (a.AddressName != null && a.AddressName.Contains(street)))
                        && (string.IsNullOrWhiteSpace(town) || (t.TownName != null && t.TownName.Contains(town)))
                    select new AddressSearchResult
                    {
                        Address = a.AddressName ?? string.Empty, // Ensure non-null values
                        PostCode = a.PostCode ?? string.Empty,
                        Town = t.TownName ?? string.Empty,
                        County = c.CountyName ?? string.Empty,
                        CountryName = co.CountryName ?? string.Empty
                    };

        return query.ToList();
    }


}