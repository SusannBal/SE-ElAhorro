using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Application.DTOs;

namespace Tienda.Application.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioResponseDto>> GetAllAsync();
        Task<UsuarioResponseDto> CreateAsync(CreateUsuarioDto dto);
        Task UpdateAsync(int id, UpdateUsuarioDto dto);
        Task DeactivateAsync(int id);
    }
}
