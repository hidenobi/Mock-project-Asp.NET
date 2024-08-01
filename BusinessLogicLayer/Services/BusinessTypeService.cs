using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class BusinessTypeService : IBusinessTypeService
{
    private readonly IBusinessTypeRepository _repository;

    public BusinessTypeService(IBusinessTypeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<BusinessType> SearchBusinessTypes(string businessName, string sicCode)
    {
        return _repository.Search(businessName, sicCode);
    }
}