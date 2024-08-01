using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;


public interface IBusinessTypeService
{
    IEnumerable<BusinessType> SearchBusinessTypes(string businessName, string sicCode);
}