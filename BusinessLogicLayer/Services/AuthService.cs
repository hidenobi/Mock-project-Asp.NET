using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogicLayer.Services;

 public class AuthService : IAuthService
 {
     private readonly ApplicationDbContext _context;
     private readonly string _secretKey;
     private readonly IConfiguration _configuration;

     public AuthService(ApplicationDbContext context, IConfiguration configuration)
     {
         _context = context;
        var jwtSecretKey = configuration["Jwt:SecretKey"];
        _secretKey = jwtSecretKey ?? throw new ArgumentNullException(nameof(jwtSecretKey), "Jwt:SecretKey configuration value is null");
        _configuration = configuration;
     }

     public AuthService(string httpsLocalhost)
     {
         throw new NotImplementedException();
     }

     public async Task<string> LoginAsync(LoginViewModel model)
     {
         var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
         if (user == null)
         {
            throw new InvalidOperationException("User not found.");
         }

         var tokenHandler = new JwtSecurityTokenHandler();
         var key = Encoding.ASCII.GetBytes(_secretKey);
         var tokenDescriptor = new SecurityTokenDescriptor
         {
             Subject = new ClaimsIdentity(new Claim[]
             {
                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Role, user.Role)
             }),
             Expires = DateTime.UtcNow.AddHours(1),
             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
         };

         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
     }
     
     
     public async Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model)
     {
         var user = await _context.Users
             .SingleOrDefaultAsync(u => u.Username == model.Username && u.Email == model.Email);

         if (user == null)
         {
             return false;
         }

         var smtpSettings = _configuration.GetSection("Smtp");

         var smtpClient = new SmtpClient(smtpSettings["Host"])
         {
             Port = int.Parse(smtpSettings["Port"]),
             Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
             EnableSsl = true
         };

         var mailMessage = new MailMessage
         {
             From = new MailAddress(smtpSettings["From"]),
             Subject = "Your Password",
             Body = $"Your password is: {user.Password}",
             IsBodyHtml = true,
         };

         mailMessage.To.Add(model.Email);

         await smtpClient.SendMailAsync(mailMessage);

         return true;
     }


 }