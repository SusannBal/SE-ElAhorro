using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol?> GetByNombreAsync(string nombre); 
        Task AddAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task SaveChangesAsync();
    }
}
