using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;

namespace Tienda.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _service.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _service.GetByIdAsync(id);
            if (producto == null) return NotFound("Producto no encontrado");
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producto = await _service.CreateAsync(dto);
            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto);
            return Ok("Producto actualizado");
        }

        
        [HttpPut("{id}/sumar-stock")]
        public async Task<IActionResult> SumarStock(int id, [FromBody] IngresoStockDto dto)
        {
            try
            {
                await _service.SumarStockAsync(id, dto.Cantidad);

                return Ok(new { mensaje = "Stock actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("{id}/proveedores")]
        public async Task<IActionResult> AsignarProveedor(int id, [FromBody] AsignarProveedorDto dto)
        {
            try
            {
                await _service.AsignarProveedorAsync(id, dto.IdProveedor, dto.Detalle);
                return Ok(new { mensaje = "Proveedor asignado correctamente al producto" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _service.DeactivateAsync(id);
            return Ok("Producto desactivado");
        }
    }
}