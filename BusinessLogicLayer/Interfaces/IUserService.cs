using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces;

public interface IUserService
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<List<User>> GetAllUsersAsync();
}