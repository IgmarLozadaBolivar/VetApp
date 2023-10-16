using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Persistence;
namespace API.Controllers;

public class UserController : ControllerBase
{
    private readonly DbAppContext _context;
    private readonly IUserService _userService;

    public UserController(IUserService userService, DbAppContext context)
    {
        _userService = userService;
        _context = context;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> RegistrarUsuario([FromBody] UserRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultRegister = await _userService.Registrar(request);

        if (resultRegister.Result)
        {
            return Ok(resultRegister);
        }
        else
        {
            return BadRequest(resultRegister);
        }
    }

    [HttpPost("loguear")]
    public async Task<IActionResult> LoguearUsuario([FromBody] UserRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("El nombre de usuario y la contraseña son obligatorios!");
        }

        var response = await _userService.Loguear(request);

        if (response.Result)
        {
            return Ok(new { result = response.Result, token = response.Token, message = response.Msg });
        }
        else
        {
            return Unauthorized(new { result = response.Result, message = response.Msg });
        }
    }
}