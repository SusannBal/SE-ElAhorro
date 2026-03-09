using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Application.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock?> GetByIdProductoAsync(int idProducto);
        Task UpdateAsync(Stock stock);
    }
}