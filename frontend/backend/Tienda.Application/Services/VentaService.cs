using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Application.Wrappers;
using Tienda.Domain.Entities;

namespace Tienda.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IStockRepository _stockRepository;

        public VentaService(
           IVentaRepository ventaRepository,
            IProductoRepository productoRepository,
            IUsuarioRepository usuarioRepository,
            IStockRepository stockRepository)
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
            _usuarioRepository = usuarioRepository;
            _stockRepository = stockRepository;
        }

        public async Task<Result<List<Venta>>> GetAllAsync()
        {
            var ventas = await _ventaRepository.GetAllAsync();
            return Result<List<Venta>>.Success(ventas);
        }

        public async Task<Result<Venta>> GetByIdAsync(int id)
        {
            var venta = await _ventaRepository.GetByIdAsync(id);
            if (venta == null) return Result<Venta>.Failure("Venta no encontrada");
            return Result<Venta>.Success(venta);
        }

        public async Task<Result<Venta>> CreateAsync(CreateVentaDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null) return Result<Venta>.Failure("El usuario no existe");

            decimal totalVenta = 0;
            var detallesVenta = new List<DetalleVenta>();
            var stocksAActualizar = new List<Stock>();

            foreach (var item in dto.Detalles)
            {
                var producto = await _productoRepository.GetByIdAsync(item.IdProducto);

                if (producto == null)
                    return Result<Venta>.Failure($"El producto con ID {item.IdProducto} no existe");

                if (producto.Estado != "Activo")
                    return Result<Venta>.Failure($"El producto '{producto.Nombre}' no está disponible");

                var stock = await _stockRepository.GetByIdProductoAsync(item.IdProducto);

                if (stock == null || stock.Cantidad < item.Cantidad)
                    return Result<Venta>.Failure($"Stock insuficiente para '{producto.Nombre}'. Disponible: {stock?.Cantidad ?? 0}");

                stock.Cantidad -= item.Cantidad; 
                stocksAActualizar.Add(stock);
 

                decimal subTotal = producto.Precio * item.Cantidad;
                totalVenta += subTotal;

                detallesVenta.Add(new DetalleVenta
                {
                    IdProducto = item.IdProducto,
                    Cantidad = item.Cantidad,
                    SubTotal = subTotal
                });
            }

            var nuevaVenta = new Venta
            {
                IdUsuario = dto.IdUsuario,
                Fecha_Compra = DateTime.Now,
                Total = totalVenta,
                Estado = "Completada",
                Detalles = detallesVenta
            };

            await _ventaRepository.AddAsync(nuevaVenta);

            foreach (var stock in stocksAActualizar)
            {
                await _stockRepository.UpdateAsync(stock);
            }

 
            await _ventaRepository.SaveChangesAsync();

            return Result<Venta>.Success(nuevaVenta);
        }

        public async Task<Result<string>> AnularVentaAsync(int id)
        {
            var venta = await _ventaRepository.GetByIdAsync(id);
            if (venta == null) return Result<string>.Failure("Venta no encontrada");

            if (venta.Estado == "Anulada") return Result<string>.Failure("La venta ya estaba anulada");

            venta.Estado = "Anulada";
            await _ventaRepository.UpdateAsync(venta);

          
            foreach (var detalle in venta.Detalles)
            {
                var stock = await _stockRepository.GetByIdProductoAsync(detalle.IdProducto);
                if (stock != null)
                {
                    stock.Cantidad += detalle.Cantidad; 
                    await _stockRepository.UpdateAsync(stock);
                }
            }

            await _ventaRepository.SaveChangesAsync();

            return Result<string>.Success("Venta anulada correctamente y stock restaurado");
        }
    }
}