using API.Models;
namespace API.Services;

public interface IUserService
{
    Task<UserResponse> Registrar(UserRequest request);
    Task<UserResponse> Loguear(UserRequest request);
}