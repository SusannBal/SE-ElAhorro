using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;

namespace Tienda.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly TiendaDbContext _context;

        public ProveedorRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await _context.Proveedores.AddAsync(proveedor);
        }

        public async Task UpdateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
        }

        public async Task DeleteAsync(Proveedor proveedor)
        {
            _context.Proveedores.Remove(proveedor);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}