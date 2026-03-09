using System;
using System.Threading.Tasks;
using Tienda.Application.DTOs;
using Tienda.Application.Interfaces;
using Tienda.Application.Wrappers;
using BCrypt.Net;

namespace Tienda.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(IUsuarioRepository usuarioRepository, IJwtGenerator jwtGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<Result<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(request.Usuario);

            if (usuario == null)
                return Result<LoginResponseDto>.Unauthorized("Usuario no encontrado");

            if (usuario.Bloqueado)
                return Result<LoginResponseDto>.Unauthorized("Usuario bloqueado por demasiados intentos");

            bool passwordValida = BCrypt.Net.BCrypt.Verify(request.Contrasena, usuario.Contrasena);

            if (!passwordValida)
            {
                usuario.IntentosFallidos++;

                if (usuario.IntentosFallidos >= 3)
                {
                    usuario.Bloqueado = true;
                }

                await _usuarioRepository.UpdateAsync(usuario);
                await _usuarioRepository.SaveChangesAsync();

                return Result<LoginResponseDto>.Unauthorized("Contraseña incorrecta");
            }

            if (usuario.Estado != "Activo")
                return Result<LoginResponseDto>.Unauthorized("Usuario inactivo");

            usuario.IntentosFallidos = 0;

            await _usuarioRepository.UpdateAsync(usuario);
            await _usuarioRepository.SaveChangesAsync();

            var token = _jwtGenerator.Generate(usuario);

            var responseDto = new LoginResponseDto
            {
                Token = token,
                Rol = usuario.Rol.Nombre,
                Nombre = usuario.Nombre
            };

            return Result<LoginResponseDto>.Success(responseDto);
        }
    }
}