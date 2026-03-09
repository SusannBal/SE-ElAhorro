using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;

namespace Tienda.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IStockRepository _stockRepository; 

        public ProductoService(IProductoRepository repository, IStockRepository stockRepository)
        {
            _repository = repository;
            _stockRepository = stockRepository;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Producto> CreateAsync(CreateProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Codigo = dto.Codigo,
                Precio = dto.Precio,
                Fecha_Vencimiento = dto.Fecha_Vencimiento,
                Estado = "Activo",
            
                Stock = new Stock
                {
                    Cantidad = 0
                }
            };

            await _repository.AddAsync(producto);
            await _repository.SaveChangesAsync(); 

            return producto;
        }

        public async Task UpdateAsync(int id, UpdateProductoDto dto)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null) throw new Exception("Producto no encontrado");

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Fecha_Vencimiento = dto.Fecha_Vencimiento;
            if (!string.IsNullOrEmpty(dto.Estado)) producto.Estado = dto.Estado;

            await _repository.UpdateAsync(producto);
            await _repository.SaveChangesAsync();
        }

        public async Task DeactivateAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null) throw new Exception("Producto no encontrado");

            producto.Estado = "Inactivo";
            await _repository.UpdateAsync(producto);
            await _repository.SaveChangesAsync();
        }

        public async Task SumarStockAsync(int idProducto, decimal cantidadIngresada)
        {
            if (cantidadIngresada <= 0)
                throw new Exception("La cantidad a ingresar debe ser mayor a 0");

            var stock = await _stockRepository.GetByIdProductoAsync(idProducto);
            if (stock == null)
                throw new Exception("No se encontró el registro de stock para este producto");

            stock.Cantidad += cantidadIngresada; 

            await _stockRepository.UpdateAsync(stock);

            await _repository.SaveChangesAsync();
        }

        public async Task AsignarProveedorAsync(int idProducto, int idProveedor, string detalle)
        {
            var producto = await _repository.GetByIdAsync(idProducto);
            if (producto == null) throw new Exception("Producto no encontrado");

            // You might want to check if the Proveedor exists here, but lacking IProveedorRepository locally, we trust the FK constraint or UI.
            await _repository.AddProveedorAsync(idProducto, idProveedor, detalle);
            await _repository.SaveChangesAsync();
        }
    }
}