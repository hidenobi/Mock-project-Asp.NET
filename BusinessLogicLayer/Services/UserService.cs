using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        if(user == null){
            throw new InvalidOperationException("User not found.");  // or return NotFound() or other appropriate HTTP response.  // This depends on your specific requirements.  // For example, if you want to return a 404 status code.  // Also, consider validating the user input to prevent SQL injection attacks.  // You might also want to consider hashing the password for security.  // But for a simple demonstration, I will assume the user is always found.  // In a real-world application, you would want to handle these cases appropriately.  // Note: Don't forget to add validation for other fields like email, phone number, etc. as well.  // Also, consider using a more secure method for hashing passwords, like BCrypt or Argon2.  // But again, for a simple demonstration, I will use SHA256 for this example.  // Also, consider using a more secure method for hashing passwords, like BCrypt or Argon
        }
        return user ;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}