using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IAddressRepository
{
    IEnumerable<AddressSearchResult> Search(string postcode, string street, string town);
}