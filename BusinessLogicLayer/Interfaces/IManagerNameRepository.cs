using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IManagerNameRepository
{
    Task<IEnumerable<ManagerName>> GetAllManagerName();
    Task<ManagerName?> GetManagerNameById(int id);
}