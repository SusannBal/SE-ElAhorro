using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Tienda.Infrastructure.Repositories
{
    public class VentaRepository:IVentaRepository
    {
        private readonly TiendaDbContext _context;

        public VentaRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> GetAllAsync()
        {
            return await _context.Ventas
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Producto)
                .ToListAsync();
        }

        public async Task<Venta?> GetByIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Usuario)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
        }

        public async Task UpdateAsync(Venta venta)
        {
            _context.Ventas.Update(venta);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
