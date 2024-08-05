using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IManagerNameService
{
    Task<IEnumerable<ManagerName>> GetAllManagerName();
    Task<ManagerName?> GetManagerNameById(int id);
}