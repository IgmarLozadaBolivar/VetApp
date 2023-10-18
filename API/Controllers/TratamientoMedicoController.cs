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

public class TratamientoMedicoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var tratamientoMedicos = await unitOfWork.TratamientoMedicos.GetAllAsync();
        return mapper.Map<List<TratamientoMedicoDto>>(tratamientoMedicos);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedicoDto>> Get(string id)
    {
        var tratamientoMedico = await unitOfWork.TratamientoMedicos.GetByIdAsync(id);
        if (tratamientoMedico == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TratamientoMedicoDto>(tratamientoMedico);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado, Usuario")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TratamientoMedicoxManyDto>>> Get11([FromQuery] Params tratamientoMedicoParams)
    {
        var tratamientoMedicos = await unitOfWork.TratamientoMedicos.GetAllAsync(tratamientoMedicoParams.PageIndex, tratamientoMedicoParams.PageSize, tratamientoMedicoParams.Search);

        foreach (var tratamientoMedico in tratamientoMedicos.registros)
        {
            await unitOfWork.TratamientoMedicos.LoadCitasAsync(tratamientoMedico);
            await unitOfWork.TratamientoMedicos.LoadMedicamentosAsync(tratamientoMedico);
        }

        var lstTratamientoMedicoDto = mapper.Map<List<TratamientoMedicoxManyDto>>(tratamientoMedicos.registros);

        return new Pager<TratamientoMedicoxManyDto>(lstTratamientoMedicoDto, tratamientoMedicos.totalRegistros, tratamientoMedicoParams.PageIndex, tratamientoMedicoParams.PageSize, tratamientoMedicoParams.Search);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedicoDto>> Post(TratamientoMedicoDto tratamientoMedicoDto)
    {
        var tratamientoMedico = mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
        unitOfWork.TratamientoMedicos.Add(tratamientoMedico);
        await unitOfWork.SaveAsync();
        if (tratamientoMedico == null)
        {
            return BadRequest();
        }
        tratamientoMedicoDto.Id = tratamientoMedico.Id;
        return CreatedAtAction(nameof(Post), new { id = tratamientoMedicoDto.Id }, tratamientoMedicoDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedicoDto>> Put(string id, [FromBody] TratamientoMedicoDto tratamientoMedicoDto)
    {
        if (tratamientoMedicoDto == null)
        {
            return NotFound();
        }
        var tratamientoMedico = mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
        unitOfWork.TratamientoMedicos.Update(tratamientoMedico);
        await unitOfWork.SaveAsync();
        return tratamientoMedicoDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var tratamientoMedico = await unitOfWork.TratamientoMedicos.GetByIdAsync(id);
        if (tratamientoMedico == null)
        {
            return NotFound();
        }
        unitOfWork.TratamientoMedicos.Remove(tratamientoMedico);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}