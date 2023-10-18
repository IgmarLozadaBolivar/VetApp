using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
namespace API.Services;

public class UserService : IUserService
{
    private readonly DbAppContext _context;
    private readonly IConfiguration _configuration;

    public UserService(DbAppContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

    }

    public async Task<UserResponse> Registrar(UserRequest request)
    {
        var usuarioExistente = _context.Users.FirstOrDefault(
            x => x.Username == request.Username);
        if (usuarioExistente != null)
        {
            return new UserResponse { Result = false, Msg = "El usuario ingresado ya existe!" };
        }

        var newUser = new User
        {
            Mail = request.Email,
            Username = request.Username,
            Password = request.Password
        };

        _context.Users.Add(newUser);

        await _context.SaveChangesAsync();

        return new UserResponse { Result = true, Msg = "Tu registro fue exitoso!" };
    }

    public async Task<RolResponse> AsignarRolAUsuario(RolRequest request)
    {
        try
        {
            var usuario = await _context.Users.FindAsync(request.IdUser);
            var rol = await _context.Rols.FindAsync(request.IdRol);

            if (usuario != null && rol != null)
            {
                var userRol = new UserRol
                {
                    IdUserFK = request.IdUser,
                    IdRolFK = request.IdRol
                };

                _context.UserRols.Add(userRol);
                await _context.SaveChangesAsync();

                return new RolResponse
                {
                    Result = true,
                    RolAsignado = rol.Nombre,
                    Msg = "Rol asignado correctamente!"
                };
            }
            else
            {
                return new RolResponse
                {
                    Result = false,
                    Msg = "No se pudo asignar el rol, usuario o rol no encontrados!"
                };
            }
        }
        catch (Exception)
        {
            return new RolResponse
            {
                Result = false,
                Msg = "Hubo un error al asignar el rol!"
            };
        }
    }

    public async Task<UserResponse> Loguear(UserRequest request)
    {
        var usuarioEncontrado = await _context.Users
            .Include(u => u.Rols)
            .FirstOrDefaultAsync(x =>
                x.Username == request.Username &&
                x.Password == request.Password
            );

        if (usuarioEncontrado != null)
        {
            var roles = usuarioEncontrado.Rols.Select(r => r.Nombre).ToList();
            string tokenCreado = GenerarToken(usuarioEncontrado.Id.ToString(), roles);

            var refreshToken = new RefreshToken
            {
                IdUserFK = usuarioEncontrado.Id,
                Token = tokenCreado,
                Expires = DateTime.UtcNow.AddMinutes(5),
                Created = DateTime.UtcNow,
            };

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new UserResponse { Result = true, Token = tokenCreado, Msg = "Tu inicio de sesion fue exitoso!" };
        }
        else
        {
            return new UserResponse { Result = false, Msg = "Credenciales de inicio de sesion incorrectas!" };
        }
    }

    private string GenerarToken(string idUser, List<string> roles)
    {
        var Key = _configuration.GetValue<string>("JwtSettings:Key");
        var keyBytes = Encoding.ASCII.GetBytes(Key);

        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUser));

        var credencialesToken = new SigningCredentials(
            new SymmetricSecurityKey(keyBytes),
            SecurityAlgorithms.HmacSha256Signature
        );

        foreach (var role in roles)
        {
            claims.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {

            Subject = claims,
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = credencialesToken
        };

        var tokenHeadler = new JwtSecurityTokenHandler();
        var tokenConfig = tokenHeadler.CreateToken(tokenDescriptor);
        string tokenCreado = tokenHeadler.WriteToken(tokenConfig);

        return tokenCreado;
    }

    public async Task<TokenResponse> ValidarToken(TokenRequest request)
    {
        var tokenEncontrado = await _context.RefreshTokens
            .FirstOrDefaultAsync(x =>
                x.Token == request.Token
            );
        if (tokenEncontrado != null)
        {

            var user = await _context.Users.FindAsync(tokenEncontrado.IdUserFK);
            var roles = user.Rols.Select(r => r.Nombre).ToList();

            string tokenCreado = GenerarToken(tokenEncontrado.Id.ToString(), roles);
            
            return new TokenResponse { Result = true, Msg = "Tu token es valido!" };
        }
        else
        {
            return new TokenResponse { Result = false, Msg = "Tu token ingresado es invalido!" };
        }
    }
}