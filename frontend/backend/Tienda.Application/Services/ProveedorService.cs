using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Application.Wrappers;
using Tienda.Domain.Entities;

namespace Tienda.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;

        public ProveedorService(IProveedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Proveedor>>> GetAllAsync()
        {
            var proveedores = await _repository.GetAllAsync();
            return Result<List<Proveedor>>.Success(proveedores);
        }

        public async Task<Result<Proveedor>> GetByIdAsync(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) return Result<Proveedor>.Failure("Proveedor no encontrado");

            return Result<Proveedor>.Success(proveedor);
        }

        public async Task<Result<Proveedor>> CreateAsync(CreateProveedorDto dto)
        {
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Relacion = dto.Relacion
            };

            await _repository.AddAsync(proveedor);
            await _repository.SaveChangesAsync();

            return Result<Proveedor>.Success(proveedor);
        }

        public async Task<Result<string>> UpdateAsync(int id, UpdateProveedorDto dto)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) return Result<string>.Failure("Proveedor no encontrado");

            proveedor.Nombre = dto.Nombre;
            proveedor.Telefono = dto.Telefono;
            proveedor.Relacion = dto.Relacion;

            await _repository.UpdateAsync(proveedor);
            await _repository.SaveChangesAsync();

            return Result<string>.Success("Proveedor actualizado correctamente");
        }

        public async Task<Result<string>> DeleteAsync(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) return Result<string>.Failure("Proveedor no encontrado");

            await _repository.DeleteAsync(proveedor);
            await _repository.SaveChangesAsync();

            return Result<string>.Success("Proveedor eliminado correctamente");
        }
    }
}