using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;


public interface IBusinessTypeRepository
{
    IEnumerable<BusinessType> Search(string businessName, string sicCode);
}