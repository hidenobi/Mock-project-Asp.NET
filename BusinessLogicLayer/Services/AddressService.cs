using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public IEnumerable<AddressSearchResult> SearchAddresses(string? postcode, string? street, string? town)
    {
        // You might want to add some logic here to handle empty strings as well
        postcode = string.IsNullOrWhiteSpace(postcode) ? null : postcode;
        street = string.IsNullOrWhiteSpace(street) ? null : street;
        town = string.IsNullOrWhiteSpace(town) ? null : town;

        return _addressRepository.Search(postcode, street, town);
    }
}