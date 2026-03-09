using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;

namespace Tienda.API.Controllers
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
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(request);

            if (!result.IsSuccess)
            {
                if (result.IsUnauthorized)
                    return Unauthorized(new { mensaje = result.ErrorMessage });

                return BadRequest(new { mensaje = result.ErrorMessage });
            }

            return Ok(result.Value);
        }
    }
}