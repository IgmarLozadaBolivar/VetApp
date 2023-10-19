using API.Models;
namespace API.Services;

public interface IUserService
{
    Task<UserResponse> Registrar(UserRequest request);
    Task<UserResponse> Loguear(UserRequest request);
    Task<TokenResponse> ValidarToken(TokenRequest request);
    Task<RolResponse> AsignarRolAUsuario(RolRequest request);
    Task<RefreshTokenResponse> DevolverTokenRefresh(RefreshTokenRequest refreshTokenRequest, int idUser);
}