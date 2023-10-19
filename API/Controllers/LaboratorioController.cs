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

public class LaboratorioController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDto>>> Get()
    {
        var laboratorios = await unitOfWork.Laboratorios.GetAllAsync();
        return mapper.Map<List<LaboratorioDto>>(laboratorios);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> Get(int id)
    {
        var laboratorio = await unitOfWork.Laboratorios.GetByIdAsync(id);
        if (laboratorio == null)
        {
            return NotFound();
        }
        return mapper.Map<LaboratorioDto>(laboratorio);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LaboratorioxManyDto>>> Get11([FromQuery] Params laboratorioParams)
    {
        var laboratorios = await unitOfWork.Laboratorios.GetAllAsync(laboratorioParams.PageIndex, laboratorioParams.PageSize, laboratorioParams.Search);

        foreach (var many in laboratorios.registros)
        {
            await unitOfWork.Laboratorios.LoadMedicamentosAsync(many.Id);
        }

        var lstLaboratorioDto = mapper.Map<List<LaboratorioxManyDto>>(laboratorios.registros);

        return new Pager<LaboratorioxManyDto>(lstLaboratorioDto, laboratorios.totalRegistros, laboratorioParams.PageIndex, laboratorioParams.PageSize, laboratorioParams.Search);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> Post(LaboratorioDto laboratorioDto)
    {
        var laboratorio = mapper.Map<Laboratorio>(laboratorioDto);
        unitOfWork.Laboratorios.Add(laboratorio);
        await unitOfWork.SaveAsync();
        if (laboratorio == null)
        {
            return BadRequest();
        }
        laboratorioDto.Id = laboratorio.Id;
        return CreatedAtAction(nameof(Post), new { id = laboratorioDto.Id }, laboratorioDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LaboratorioDto>> Put(int id, [FromBody] LaboratorioDto laboratorioDto)
    {
        if (laboratorioDto == null)
        {
            return NotFound();
        }
        var laboratorio = mapper.Map<Laboratorio>(laboratorioDto);
        unitOfWork.Laboratorios.Update(laboratorio);
        await unitOfWork.SaveAsync();
        return laboratorioDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var laboratorio = await unitOfWork.Laboratorios.GetByIdAsync(id);
        if (laboratorio == null)
        {
            return NotFound();
        }
        unitOfWork.Laboratorios.Remove(laboratorio);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}