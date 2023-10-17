using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamentos = await unitOfWork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Get(string id)
    {
        var medicamento = await unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null){
           return NotFound();
        }
        return mapper.Map<MedicamentoDto>(medicamento);
    }

    [HttpGet("api/Many11")]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> MedicamentosLaboratoriosGenfar()
    {
        var medicamentosGenfar = await unitOfWork.Medicamentos.MedicamentosLaboratoriosGenfar();
        return mapper.Map<List<MedicamentoDto>>(medicamentosGenfar);
    }

    [HttpGet("precioMayorA50k")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> PrecioMayorA50k()
    {
        var precioMayorA50k = await unitOfWork.Medicamentos.PrecioMayorA50k();
        return mapper.Map<List<MedicamentoDto>>(precioMayorA50k);
    }

    [HttpPost]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicamentoDto>> Put(string id, [FromBody] MedicamentoDto medicamentoDto)
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
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