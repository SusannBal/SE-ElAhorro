using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;

namespace Tienda.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _service;

        public VentasController(IVentaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess) return NotFound(new { mensaje = result.ErrorMessage });

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVentaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            if (!result.IsSuccess) return BadRequest(new { mensaje = result.ErrorMessage });

            return Ok(result.Value);
        }

        [HttpPut("{id}/anular")]
        public async Task<IActionResult> Anular(int id)
        {
            var result = await _service.AnularVentaAsync(id);
            if (!result.IsSuccess) return BadRequest(new { mensaje = result.ErrorMessage });

            return Ok(new { mensaje = result.Value });
        }
    }
}