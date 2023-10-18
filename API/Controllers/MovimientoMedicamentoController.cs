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

public class MovimientoMedicamentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> Get()
    {
        var movimientoMedicamentos = await unitOfWork.MovimientoMedicamentos.GetAllAsync();
        return mapper.Map<List<MovimientoMedicamentoDto>>(movimientoMedicamentos);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamentoDto>> Get(string id)
    {
        var movimientoMedicamento = await unitOfWork.MovimientoMedicamentos.GetByIdAsync(id);
        if (movimientoMedicamento == null)
        {
            return NotFound();
        }
        return mapper.Map<MovimientoMedicamentoDto>(movimientoMedicamento);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovimientoMedicamentoxManyDto>>> Get11([FromQuery] Params movimientoMedicoParams)
    {
        var movimientoMedicamentos = await unitOfWork.MovimientoMedicamentos.GetAllAsync(movimientoMedicoParams.PageIndex, movimientoMedicoParams.PageSize, movimientoMedicoParams.Search);

        foreach (var movimientoMedicamento in movimientoMedicamentos.registros)
        {
            await unitOfWork.MovimientoMedicamentos.LoadMedicamentosAsync(movimientoMedicamento);
            await unitOfWork.MovimientoMedicamentos.LoadPropietariosAsync(movimientoMedicamento);
            await unitOfWork.MovimientoMedicamentos.LoadTipoMovimientosAsync(movimientoMedicamento);
        }

        var lstMovimientoMedicamentoDto = mapper.Map<List<MovimientoMedicamentoxManyDto>>(movimientoMedicamentos.registros);

        return new Pager<MovimientoMedicamentoxManyDto>(lstMovimientoMedicamentoDto, movimientoMedicamentos.totalRegistros, movimientoMedicoParams.PageIndex, movimientoMedicoParams.PageSize, movimientoMedicoParams.Search);
    }

    [HttpGet("totalMovimiento")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> TotalCadaMovimiento()
    {
        var entidad = await unitOfWork.MovimientoMedicamentos.TotalCadaMovimiento();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoMedicamentoDto>> Post(MovimientoMedicamentoDto movimientoMedicamentoDto)
    {
        var movimientoMedicamento = mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        unitOfWork.MovimientoMedicamentos.Add(movimientoMedicamento);
        await unitOfWork.SaveAsync();
        if (movimientoMedicamento == null)
        {
            return BadRequest();
        }
        movimientoMedicamentoDto.Id = movimientoMedicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoMedicamentoDto.Id }, movimientoMedicamentoDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MovimientoMedicamentoDto>> Put(string id, [FromBody] MovimientoMedicamentoDto movimientoMedicamentoDto)
    {
        if (movimientoMedicamentoDto == null)
        {
            return NotFound();
        }
        var movimientoMedicamento = mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        unitOfWork.MovimientoMedicamentos.Update(movimientoMedicamento);
        await unitOfWork.SaveAsync();
        return movimientoMedicamentoDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var movimientoMedicamento = await unitOfWork.MovimientoMedicamentos.GetByIdAsync(id);
        if (movimientoMedicamento == null)
        {
            return NotFound();
        }
        unitOfWork.MovimientoMedicamentos.Remove(movimientoMedicamento);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}