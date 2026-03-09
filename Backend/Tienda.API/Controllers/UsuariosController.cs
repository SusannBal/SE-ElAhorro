using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Application.Services;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _service.GetAllAsync();
        return Ok(usuarios);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUsuarioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var usuario = await _service.CreateAsync(dto);

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUsuarioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.UpdateAsync(id, dto);

        return Ok("Usuario actualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await _service.DeactivateAsync(id);

        return Ok("Usuario desactivado");
    }
}