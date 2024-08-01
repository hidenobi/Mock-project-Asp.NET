
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;


public interface IAddressService
{
    IEnumerable<AddressSearchResult> SearchAddresses(string postcode, string street, string town);
}