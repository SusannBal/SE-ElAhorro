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
    public class RolesController : ControllerBase
    {
        private readonly IRolService _service;

        public RolesController(IRolService service)
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
        public async Task<IActionResult> Create(CreateRolDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            if (!result.IsSuccess) return BadRequest(new { mensaje = result.ErrorMessage });

            return Ok(result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRolDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            if (!result.IsSuccess) return BadRequest(new { mensaje = result.ErrorMessage });

            return Ok(new { mensaje = result.Value });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _service.DeactivateAsync(id);
            if (!result.IsSuccess) return BadRequest(new { mensaje = result.ErrorMessage });

            return Ok(new { mensaje = result.Value });
        }
    }
}