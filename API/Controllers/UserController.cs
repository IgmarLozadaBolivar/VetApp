using System.IdentityModel.Tokens.Jwt;
using API.Dtos;
using API.Models;
using API.Services;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;
namespace API.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly DbAppContext _context;
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserController(IUserService userService, DbAppContext context, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _context = context;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await unitOfWork.Users.GetAllAsync();
        return mapper.Map<List<UserDto>>(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return this.mapper.Map<UserDto>(user);
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

    [HttpPost("asignar-rol")]
    public async Task<ActionResult<RolResponse>> AsignarRolAUsuario([FromBody] RolRequest request)
    {
        try
        {
            var response = await _userService.AsignarRolAUsuario(request);

            if (response.Result)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        catch (Exception)
        {
            return StatusCode(500, new RolResponse
            {
                Result = false,
                Msg = "Error interno del servidor"
            });
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

    [HttpPost("validarToken")]
    public async Task<IActionResult> ValidarToken([FromBody] TokenRequest request)
    {
        var response = await _userService.ValidarToken(request);

        if (response.Result)
        {

            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    [HttpPost("refrescarToken")]
    public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenExpiradoSupuestamente = tokenHandler.ReadJwtToken(request.TokenExpirado);

        if (tokenExpiradoSupuestamente.ValidTo > DateTime.UtcNow)
            return BadRequest(new RefreshTokenResponse { Result = false, Msg = "Token no ha expirado" });

        string idUser = tokenExpiradoSupuestamente.Claims.First(x =>
            x.Type == JwtRegisteredClaimNames.NameId
        ).Value.ToString();

        var autorizacionResponse = await _userService.DevolverTokenRefresh(request, int.Parse(idUser));

        if (autorizacionResponse.Result)
            return Ok(autorizacionResponse);
        else
            return BadRequest(autorizacionResponse);
    }
}