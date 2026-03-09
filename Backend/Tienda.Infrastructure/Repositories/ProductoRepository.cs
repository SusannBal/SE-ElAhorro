using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;

namespace Tienda.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TiendaDbContext _context;

        public ProductoRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(p => p.Stock)
                .Include(p => p.ProductoProveedores)
                    .ThenInclude(pp => pp.Proveedor)
                .ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Stock)
                .Include(p => p.ProductoProveedores)
                    .ThenInclude(pp => pp.Proveedor)
                .FirstOrDefaultAsync(p => p.IdProducto == id);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddProveedorAsync(int idProducto, int idProveedor, string detalle)
        {
            var relacion = new ProductoProveedor
            {
                IdProducto = idProducto,
                IdProveedor = idProveedor,
                Detalle = detalle,
                Estado = "Activo"
            };
            
            await _context.Set<ProductoProveedor>().AddAsync(relacion);
        }
    }
}