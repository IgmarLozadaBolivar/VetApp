using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class RazaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
    {
        var razas = await unitOfWork.Razas.GetAllAsync();
        return mapper.Map<List<RazaDto>>(razas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> Get(string id)
    {
        var raza = await unitOfWork.Razas.GetByIdAsync(id);
        if (raza == null)
        {
            return NotFound();
        }
        return this.mapper.Map<RazaDto>(raza);
    }

    [HttpGet("api/Many11")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<RazaxManyDto>>> Get11([FromQuery] Params razaParams)
    {
        var razas = await unitOfWork.Razas.GetAllAsync(razaParams.PageIndex, razaParams.PageSize, razaParams.Search);

        foreach (var raza in razas.registros)
        {
            await unitOfWork.Razas.LoadEspeciesAsync(raza);
            await unitOfWork.Razas.LoadMascotasAsync(raza.Id);
        }

        var lstRazaDto = mapper.Map<List<RazaxManyDto>>(razas.registros);

        return new Pager<RazaxManyDto>(lstRazaDto, razas.totalRegistros, razaParams.PageIndex, razaParams.PageSize, razaParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> Post(RazaDto razaDto)
    {
        var raza = mapper.Map<Raza>(razaDto);
        unitOfWork.Razas.Add(raza);
        await unitOfWork.SaveAsync();
        if (raza == null)
        {
            return BadRequest();
        }
        razaDto.Id = raza.Id;
        return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RazaDto>> Put(string id, [FromBody] RazaDto razaDto)
    {
        if (razaDto == null)
        {
            return NotFound();
        }
        var raza = mapper.Map<Raza>(razaDto);
        unitOfWork.Razas.Update(raza);
        await unitOfWork.SaveAsync();
        return razaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var raza = await unitOfWork.Razas.GetByIdAsync(id);
        if (raza == null)
        {
            return NotFound();
        }
        unitOfWork.Razas.Remove(raza);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}