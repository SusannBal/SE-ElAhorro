using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IVentaRepository
    {
        Task<List<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task AddAsync(Venta venta);
        Task UpdateAsync(Venta venta);
        Task SaveChangesAsync();
    }
}
