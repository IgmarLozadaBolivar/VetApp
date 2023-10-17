using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class TipoMovimientoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoMovimientoDto>>> Get()
    {
        var tipoMovimientos = await unitOfWork.TipoMovimientos.GetAllAsync();
        return mapper.Map<List<TipoMovimientoDto>>(tipoMovimientos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimientoDto>> Get(string id)
    {
        var tipoMovimiento = await unitOfWork.TipoMovimientos.GetByIdAsync(id);
        if (tipoMovimiento == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoMovimientoDto>(tipoMovimiento);
    }

    [HttpGet("api/Many11")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoMovimientoxManyDto>>> GetPagination([FromQuery] Params tipoMovimientoParams)
    {
        var entidad = await unitOfWork.TipoMovimientos.GetAllAsync(tipoMovimientoParams.PageIndex, tipoMovimientoParams.PageSize, tipoMovimientoParams.Search);
        var listEntidad = mapper.Map<List<TipoMovimientoxManyDto>>(entidad.registros);
        return new Pager<TipoMovimientoxManyDto>(listEntidad, entidad.totalRegistros, tipoMovimientoParams.PageIndex, tipoMovimientoParams.PageSize, tipoMovimientoParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimientoDto>> Post(TipoMovimientoDto tipoMovimientoDto)
    {
        var tipoMovimiento = mapper.Map<TipoMovimiento>(tipoMovimientoDto);
        unitOfWork.TipoMovimientos.Add(tipoMovimiento);
        await unitOfWork.SaveAsync();
        if (tipoMovimiento == null)
        {
            return BadRequest();
        }
        tipoMovimientoDto.Id = tipoMovimiento.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoMovimientoDto.Id }, tipoMovimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoDto>> Put(string id, [FromBody] TipoMovimientoDto tipoMovimientoDto)
    {
        if (tipoMovimientoDto == null)
        {
            return NotFound();
        }
        var tipoMovimiento = mapper.Map<TipoMovimiento>(tipoMovimientoDto);
        unitOfWork.TipoMovimientos.Update(tipoMovimiento);
        await unitOfWork.SaveAsync();
        return tipoMovimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var tipoMovimiento = await unitOfWork.TipoMovimientos.GetByIdAsync(id);
        if (tipoMovimiento == null)
        {
            return NotFound();
        }
        unitOfWork.TipoMovimientos.Remove(tipoMovimiento);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}