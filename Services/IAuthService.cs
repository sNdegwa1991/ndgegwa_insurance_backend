using NdegwaInsuranceApi.Models;

namespace NdegwaInsuranceApi.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        string GenerateJwtToken(Admin admin);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
