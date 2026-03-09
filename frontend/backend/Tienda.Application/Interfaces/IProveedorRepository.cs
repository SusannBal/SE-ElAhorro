using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> GetAllAsync();
        Task<Proveedor?> GetByIdAsync(int id);
        Task AddAsync(Proveedor proveedor);
        Task UpdateAsync(Proveedor proveedor);
        Task DeleteAsync(Proveedor proveedor);
        Task SaveChangesAsync();
    }
}