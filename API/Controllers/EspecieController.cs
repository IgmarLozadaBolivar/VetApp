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

public class EspecieController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var especies = await unitOfWork.Especies.GetAllAsync();
        return mapper.Map<List<EspecieDto>>(especies);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var especie = await unitOfWork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EspecieDto>(especie);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspeciexManyDto>>> Get11([FromQuery] Params especieParams)
    {
        var especies = await unitOfWork.Especies.GetAllAsync(especieParams.PageIndex, especieParams.PageSize, especieParams.Search);

        foreach (var many in especies.registros)
        {
            await unitOfWork.Especies.LoadMascotasAsync(many.Id);
            await unitOfWork.Especies.LoadRazasAsync(many.Id);
        }

        var lstEspeciesDto = mapper.Map<List<EspeciexManyDto>>(especies.registros);

        return new Pager<EspeciexManyDto>(lstEspeciesDto, especies.totalRegistros, especieParams.PageIndex, especieParams.PageSize, especieParams.Search);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> Post(EspecieDto especieDto)
    {
        var especie = mapper.Map<Especie>(especieDto);
        unitOfWork.Especies.Add(especie);
        await unitOfWork.SaveAsync();
        if (especie == null)
        {
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post), new { id = especieDto.Id }, especieDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody] EspecieDto especieDto)
    {
        if (especieDto == null)
        {
            return NotFound();
        }
        var especie = mapper.Map<Especie>(especieDto);
        unitOfWork.Especies.Update(especie);
        await unitOfWork.SaveAsync();
        return especieDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var especie = await unitOfWork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        unitOfWork.Especies.Remove(especie);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}