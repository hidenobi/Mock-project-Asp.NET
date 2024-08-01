using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class ManagerNameService
{
    private readonly IManagerNameRepository _managerNameRepository;

    public ManagerNameService(IManagerNameRepository managerNameRepository)
    {
        _managerNameRepository = managerNameRepository;
    }

    public async Task<IEnumerable<ManagerName>> GetAllManagerName()
    {
        return await _managerNameRepository.GetAllManagerName();
    }

    public async Task<ManagerName?> GetManagerNameById(int id)
    {
        return await _managerNameRepository.GetManagerNameById(id);
    }
}