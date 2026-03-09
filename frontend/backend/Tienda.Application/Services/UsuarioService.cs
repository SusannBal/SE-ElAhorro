using BCrypt.Net;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Application.Services;
using Tienda.Domain.Entities;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<UsuarioResponseDto>> GetAllAsync()
    {
        var usuarios = await _repo.GetAllAsync();

        return usuarios.Select(u => new UsuarioResponseDto
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Usuario = u.Username,
            Correo = u.Correo,
            Rol = u.Rol.Nombre,
            Estado = u.Estado,
            Bloqueado = u.Bloqueado,
            IntentosFallidos = u.IntentosFallidos
        }).ToList();
    }

    public async Task<UsuarioResponseDto> CreateAsync(CreateUsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Nombre = dto.Nombre,
            Username = dto.Usuario,
            Correo = dto.Correo,
            Contrasena = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena),
            IdRol = dto.IdRol,
            Estado = "Activo"
        };

        await _repo.AddAsync(usuario);
        await _repo.SaveChangesAsync();

        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Usuario = usuario.Username,
            Correo = usuario.Correo,
            Estado = usuario.Estado
        };
    }

    public async Task UpdateAsync(int id, UpdateUsuarioDto dto)
    {
        var usuario = await _repo.GetByIdAsync(id);

        if (usuario == null)
            throw new Exception("Usuario no encontrado");

        usuario.Nombre = dto.Nombre;
        usuario.Correo = dto.Correo;
        usuario.IdRol = dto.IdRol;
        if (!string.IsNullOrEmpty(dto.Estado))
            usuario.Estado = dto.Estado;

        if (dto.Bloqueado.HasValue)
            usuario.Bloqueado = dto.Bloqueado.Value;

        if (dto.IntentosFallidos.HasValue)
            usuario.IntentosFallidos = dto.IntentosFallidos.Value;

        await _repo.UpdateAsync(usuario);
        await _repo.SaveChangesAsync();
    }

    public async Task DeactivateAsync(int id)
    {
        var usuario = await _repo.GetByIdAsync(id);

        if (usuario == null)
            throw new Exception("Usuario no encontrado");

        usuario.Estado = "Inactivo";

        await _repo.UpdateAsync(usuario);
        await _repo.SaveChangesAsync();
    }
}