using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Data;

namespace Tienda.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly TiendaDbContext _context;

        public StockRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetByIdProductoAsync(int idProducto)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.IdProducto == idProducto);
        }

        public async Task UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
        }
    }
}