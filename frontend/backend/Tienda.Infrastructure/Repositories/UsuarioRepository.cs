using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Infrastructure.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly TiendaDbContext _context;

        public UsuarioRepository(TiendaDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> GetByUsernameAsync(string usuario)
        {
            return await _context.Usuarios
            .Include(u => u.Rol)
             .FirstOrDefaultAsync(u => u.Username == usuario);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
