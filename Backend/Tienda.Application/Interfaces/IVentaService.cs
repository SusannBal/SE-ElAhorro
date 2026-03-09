using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.Wrappers;
using Tienda.Application.DTOs;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IVentaService
    {
        Task<Result<List<Venta>>> GetAllAsync();
        Task<Result<Venta>> GetByIdAsync(int id);
        Task<Result<Venta>> CreateAsync(CreateVentaDto dto);
        Task<Result<string>> AnularVentaAsync(int id);
    }
}