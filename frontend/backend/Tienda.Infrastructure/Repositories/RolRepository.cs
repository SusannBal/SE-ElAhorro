using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;

namespace Tienda.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly TiendaDbContext _context;

        public RolRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rol?> GetByNombreAsync(string nombre)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == nombre);
        }

        public async Task AddAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Roles.Update(rol);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}