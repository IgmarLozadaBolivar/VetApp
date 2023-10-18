using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> Get()
    {
        var detalleMovimientos = await unitOfWork.DetalleMovimientos.GetAllAsync();
        return mapper.Map<List<DetalleMovimientoDto>>(detalleMovimientos);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimientoDto>> Get(string id)
    {
        var detalleMovimiento = await unitOfWork.DetalleMovimientos.GetByIdAsync(id);
        if (detalleMovimiento == null)
        {
            return NotFound();
        }
        return mapper.Map<DetalleMovimientoDto>(detalleMovimiento);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleMovimientoxManyDto>>> Get11([FromQuery] Params detalleMovimientoParams)
    {
        var detalleMovimientos = await unitOfWork.DetalleMovimientos.GetAllAsync(detalleMovimientoParams.PageIndex, detalleMovimientoParams.PageSize, detalleMovimientoParams.Search);

        foreach (var detalleMovimiento in detalleMovimientos.registros)
        {
            await unitOfWork.DetalleMovimientos.LoadMedicamentosAsync(detalleMovimiento);
            await unitOfWork.DetalleMovimientos.LoadMovimientoMedicamentosAsync(detalleMovimiento);
        }

        var lstDetalleMovimientoDto = mapper.Map<List<DetalleMovimientoxManyDto>>(detalleMovimientos.registros);

        return new Pager<DetalleMovimientoxManyDto>(lstDetalleMovimientoDto, detalleMovimientos.totalRegistros, detalleMovimientoParams.PageIndex, detalleMovimientoParams.PageSize, detalleMovimientoParams.Search);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimientoDto>> Post(DetalleMovimientoDto detalleMovimientoDto)
    {
        var detalleMovimiento = mapper.Map<DetalleMovimiento>(detalleMovimientoDto);
        unitOfWork.DetalleMovimientos.Add(detalleMovimiento);
        await unitOfWork.SaveAsync();
        if (detalleMovimiento == null)
        {
            return BadRequest();
        }
        detalleMovimientoDto.Id = detalleMovimiento.Id;
        return CreatedAtAction(nameof(Post), new { id = detalleMovimientoDto.Id }, detalleMovimientoDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Put(string id, [FromBody] DetalleMovimientoDto detalleMovimientoDto)
    {
        if (detalleMovimientoDto == null)
        {
            return NotFound();
        }
        var detalleMovimiento = mapper.Map<DetalleMovimiento>(detalleMovimientoDto);
        unitOfWork.DetalleMovimientos.Update(detalleMovimiento);
        await unitOfWork.SaveAsync();
        return detalleMovimientoDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var detalleMovimiento = await unitOfWork.DetalleMovimientos.GetByIdAsync(id);
        if (detalleMovimiento == null)
        {
            return NotFound();
        }
        unitOfWork.DetalleMovimientos.Remove(detalleMovimiento);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}