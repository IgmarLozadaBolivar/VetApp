using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PropietarioController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var propietarios = await unitOfWork.Propietarios.GetAllAsync();
        return mapper.Map<List<PropietarioDto>>(propietarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropietarioDto>> Get(string id)
    {
        var propietario = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (propietario == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PropietarioDto>(propietario);
    }

    [HttpGet("api/Many11")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PropietarioxManyDto>>> Get11([FromQuery] Params propietarioParams)
    {
        var propietarios = await unitOfWork.Propietarios.GetAllAsync(propietarioParams.PageIndex, propietarioParams.PageSize, propietarioParams.Search);

        foreach (var many in propietarios.registros)
        {
            await unitOfWork.Propietarios.LoadMascotasAsync(many.Id);
            await unitOfWork.Propietarios.LoadMovimientoMedicamentosAsync(many.Id);
        }

        var lstPropietarioDto = mapper.Map<List<PropietarioxManyDto>>(propietarios.registros);

        return new Pager<PropietarioxManyDto>(lstPropietarioDto, propietarios.totalRegistros, propietarioParams.PageIndex, propietarioParams.PageSize, propietarioParams.Search);
    }

    [HttpGet("mascotasConPropietarios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasConPropietarios()
    {
        var entidad = await unitOfWork.Propietarios.MascotasConPropietarios();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("mascotasGoldenRetriever")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasGoldenRetriever()
    {
        var entidad = await unitOfWork.Propietarios.MascotasGoldenRetriever();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PropietarioDto>> Post(PropietarioDto propietarioDto)
    {
        var propietario = mapper.Map<Propietario>(propietarioDto);
        unitOfWork.Propietarios.Add(propietario);
        await unitOfWork.SaveAsync();
        if (propietario == null)
        {
            return BadRequest();
        }
        propietarioDto.Id = propietario.Id;
        return CreatedAtAction(nameof(Post), new { id = propietarioDto.Id }, propietarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PropietarioDto>> Put(string id, [FromBody] PropietarioDto propietarioDto)
    {
        if (propietarioDto == null)
        {
            return NotFound();
        }
        var propietario = mapper.Map<Propietario>(propietarioDto);
        unitOfWork.Propietarios.Update(propietario);
        await unitOfWork.SaveAsync();
        return propietarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var propietario = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (propietario == null)
        {
            return NotFound();
        }
        unitOfWork.Propietarios.Remove(propietario);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}