using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Application.DTOs;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<Producto> CreateAsync(CreateProductoDto dto);
        Task UpdateAsync(int id, UpdateProductoDto dto);
        Task DeactivateAsync(int id);
        Task SumarStockAsync(int idProducto, decimal cantidadIngresada);
        Task AsignarProveedorAsync(int idProducto, int idProveedor, string detalle);
    }
}
