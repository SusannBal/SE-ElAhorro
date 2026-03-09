using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Application.DTOs;
using Tienda.Application.Wrappers;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IRolService
    {
        Task<Result<List<Rol>>> GetAllAsync();
        Task<Result<Rol>> GetByIdAsync(int id);
        Task<Result<Rol>> CreateAsync(CreateRolDto dto);
        Task<Result<string>> UpdateAsync(int id, UpdateRolDto dto);
        Task<Result<string>> DeactivateAsync(int id);
    }
}
