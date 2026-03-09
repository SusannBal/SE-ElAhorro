using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.Wrappers;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;

namespace Tienda.Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _repository;

        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Rol>>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return Result<List<Rol>>.Success(roles);
        }

        public async Task<Result<Rol>> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null) return Result<Rol>.Failure("Rol no encontrado");

            return Result<Rol>.Success(rol);
        }

        public async Task<Result<Rol>> CreateAsync(CreateRolDto dto)
        {
          
            var existeRol = await _repository.GetByNombreAsync(dto.Nombre);
            if (existeRol != null) return Result<Rol>.Failure("Ya existe un rol con ese nombre");

            var rol = new Rol
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = "Activo" 
            };

            await _repository.AddAsync(rol);
            await _repository.SaveChangesAsync();

            return Result<Rol>.Success(rol);
        }

        public async Task<Result<string>> UpdateAsync(int id, UpdateRolDto dto)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null) return Result<string>.Failure("Rol no encontrado");

            rol.Nombre = dto.Nombre;
            rol.Descripcion = dto.Descripcion;
            if (!string.IsNullOrEmpty(dto.Estado)) rol.Estado = dto.Estado;

            await _repository.UpdateAsync(rol);
            await _repository.SaveChangesAsync();

            return Result<string>.Success("Rol actualizado correctamente");
        }

        public async Task<Result<string>> DeactivateAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);
            if (rol == null) return Result<string>.Failure("Rol no encontrado");

            rol.Estado = "Inactivo";
            await _repository.UpdateAsync(rol);
            await _repository.SaveChangesAsync();

            return Result<string>.Success("Rol desactivado correctamente");
        }
    }
}