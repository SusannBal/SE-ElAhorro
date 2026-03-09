using System.Threading.Tasks;
using Tienda.Application.Wrappers;
using Tienda.Application.DTOs;

namespace Tienda.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<LoginResponseDto>> LoginAsync(LoginRequestDto request);
    }
}