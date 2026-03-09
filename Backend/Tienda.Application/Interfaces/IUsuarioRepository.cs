using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByUsernameAsync(string usuario);
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task SaveChangesAsync();
}
