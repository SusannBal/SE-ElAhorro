using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task SaveChangesAsync();
        Task AddProveedorAsync(int idProducto, int idProveedor, string detalle);
    }
}
