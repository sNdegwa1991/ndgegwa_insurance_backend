using Microsoft.AspNetCore.Mvc;
using NdegwaInsuranceApi.Models;
using NdegwaInsuranceApi.Services;

namespace NdegwaInsuranceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var response = await _authService.LoginAsync(request);

            if (response == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(response);
        }

        [HttpGet("generate-hash")]
        public ActionResult<string> GenerateHash(string password)
        {
            var hash = _authService.HashPassword(password);
            return Ok(new { hash = hash });
        }
    }
}