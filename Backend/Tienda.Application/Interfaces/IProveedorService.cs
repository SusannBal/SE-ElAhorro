using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Wrappers;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IProveedorService
    {
        Task<Result<List<Proveedor>>> GetAllAsync();
        Task<Result<Proveedor>> GetByIdAsync(int id);
        Task<Result<Proveedor>> CreateAsync(CreateProveedorDto dto);
        Task<Result<string>> UpdateAsync(int id, UpdateProveedorDto dto);
        Task<Result<string>> DeleteAsync(int id);
    }
}