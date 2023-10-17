using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CitaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
    {
        var citas = await unitOfWork.Citas.GetAllAsync();
        return mapper.Map<List<CitaDto>>(citas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitaDto>> Get(string id)
    {
        var cita = await unitOfWork.Citas.GetByIdAsync(id);
        if (cita == null)
        {
            return NotFound();
        }
        return mapper.Map<CitaDto>(cita);
    }

    [HttpGet("api/Cita11")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CitaxManyDto>>> Get11([FromQuery] Params citaParams)
    {
        var citas = await unitOfWork.Citas.GetAllAsync(citaParams.PageIndex, citaParams.PageSize, citaParams.Search);

        foreach (var cita in citas.registros)
        {
            await unitOfWork.Citas.LoadMascotasAsync(cita);
            await unitOfWork.Citas.LoadVeterinariosAsync(cita);
        }

        var lstCitaDto = mapper.Map<List<CitaxManyDto>>(citas.registros);

        return new Pager<CitaxManyDto>(lstCitaDto, citas.totalRegistros, citaParams.PageIndex, citaParams.PageSize, citaParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitaDto>> Post(CitaDto citaDto)
    {
        var cita = mapper.Map<Cita>(citaDto);
        unitOfWork.Citas.Add(cita);
        await unitOfWork.SaveAsync();
        if (cita == null)
        {
            return BadRequest();
        }
        citaDto.Id = cita.Id;
        return CreatedAtAction(nameof(Post), new { id = citaDto.Id }, citaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Put(string id, [FromBody] CitaDto citaDto)
    {
        if (citaDto == null)
        {
            return NotFound();
        }
        var cita = mapper.Map<Cita>(citaDto);
        unitOfWork.Citas.Update(cita);
        await unitOfWork.SaveAsync();
        return citaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var cita = await unitOfWork.Citas.GetByIdAsync(id);
        if (cita == null)
        {
            return NotFound();
        }
        unitOfWork.Citas.Remove(cita);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}