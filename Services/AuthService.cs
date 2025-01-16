using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using NdegwaInsuranceApi.Data;
using NdegwaInsuranceApi.Models;
using NdegwaInsuranceApi.Services;
using Microsoft.EntityFrameworkCore;

namespace NdegwaInsuranceApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {

            Console.WriteLine($"Login attempt for email: {request.Email}");

            var adminCheck = await _context.Admins.ToListAsync();
            Console.WriteLine($"Total admins in database: {adminCheck.Count}");
            foreach (var a in adminCheck)
            {
                Console.WriteLine($"Found admin: {a.Email}");
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Email.ToLower() == request.Email.ToLower());

            if (admin == null)
            {
                Console.WriteLine("Admin not found in database");
                return null;
            }

            Console.WriteLine($"Found admin with ID: {admin.Id}");
            Console.WriteLine($"Stored hash: {admin.Password}");
            Console.WriteLine($"Input password: {request.Password}");

            var isPasswordValid = VerifyPassword(request.Password, admin.Password);
            Console.WriteLine($"Password verification result: {isPasswordValid}");

            if (!isPasswordValid)
                return null;

            var token = GenerateJwtToken(admin);
            return new AuthResponse
            {
                Token = token,
                FullName = admin.FullName,
                Email = admin.Email
            };

        }

        public string GenerateJwtToken(Admin admin)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Name, admin.FullName)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying password: {ex.Message}");
                return false;
            }
        }
    }
}