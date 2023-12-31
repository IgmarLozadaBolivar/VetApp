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

public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamentos = await unitOfWork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var medicamento = await unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null){
           return NotFound();
        }
        return mapper.Map<MedicamentoDto>(medicamento);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicamentoxManyDto>>> Get11([FromQuery] Params medicamentoParams)
    {
        var medicamentos = await unitOfWork.Medicamentos.GetAllAsync(medicamentoParams.PageIndex, medicamentoParams.PageSize, medicamentoParams.Search);

        foreach (var medicamento in medicamentos.registros)
        {
            await unitOfWork.Medicamentos.LoadLaboratoriosAsync(medicamento);
        }

        var lstMedicamentoDto = mapper.Map<List<MedicamentoxManyDto>>(medicamentos.registros);

        return new Pager<MedicamentoxManyDto>(lstMedicamentoDto, medicamentos.totalRegistros, medicamentoParams.PageIndex, medicamentoParams.PageSize, medicamentoParams.Search);
    }

    [HttpGet("medicamentosGenfar")]
    [MapToApiVersion("1.0")]
    /* [Authorize(Roles = "Administrador, Empleado")] */
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> MedicamentosLaboratoriosGenfar()
    {
        var medicamentosGenfar = await unitOfWork.Medicamentos.MedicamentosLaboratoriosGenfar();
        return mapper.Map<List<MedicamentoDto>>(medicamentosGenfar);
    }

    [HttpGet("medicamentosGenfar")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MedicamentoxManyDto>>> Consulta2APag([FromQuery] Params medicamentoParams)
    {
        var entidad = await unitOfWork.Medicamentos.MedicamentosLaboratoriosGenfar(medicamentoParams.PageIndex, medicamentoParams.PageSize, medicamentoParams.Search);
        var listEntidad = mapper.Map<List<MedicamentoxManyDto>>(entidad.registros);
        return new Pager<MedicamentoxManyDto>(listEntidad, entidad.totalRegistros, medicamentoParams.PageIndex, medicamentoParams.PageSize, medicamentoParams.Search);
    }

    [HttpGet("precioMayorA50k")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> PrecioMayorA50k()
    {
        var precioMayorA50k = await unitOfWork.Medicamentos.PrecioMayorA50k();
        return mapper.Map<List<MedicamentoDto>>(precioMayorA50k);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoDto medicamentoDto)
    {
        var medicamento = mapper.Map<Medicamento>(medicamentoDto);
        unitOfWork.Medicamentos.Add(medicamento);
        await unitOfWork.SaveAsync();
        if (medicamento == null)
        {
            return BadRequest();
        }
        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = medicamentoDto.Id }, medicamentoDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody] MedicamentoDto medicamentoDto)
    {
        if (medicamentoDto == null)
        {
            return NotFound();
        }
        var medicamento = mapper.Map<Medicamento>(medicamentoDto);
        unitOfWork.Medicamentos.Update(medicamento);
        await unitOfWork.SaveAsync();
        return medicamentoDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var medicamento = await unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null)
        {
            return NotFound();
        }
        unitOfWork.Medicamentos.Remove(medicamento);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}