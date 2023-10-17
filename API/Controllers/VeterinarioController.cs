using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class VeterinarioController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var veterinarios = await unitOfWork.Veterinarios.GetAllAsync();
        return mapper.Map<List<VeterinarioDto>>(veterinarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> Get(string id)
    {
        var veterinario = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (veterinario == null){
           return NotFound();
        }
        return this.mapper.Map<VeterinarioDto>(veterinario);
    }

    [HttpGet("api/Many11")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VeterinarioxManyDto>>> Get11([FromQuery] Params veterinarioParams)
    {
        var veterinarios = await unitOfWork.Veterinarios.GetAllAsync(veterinarioParams.PageIndex, veterinarioParams.PageSize, veterinarioParams.Search);

        foreach (var many in veterinarios.registros)
        {
            await unitOfWork.Veterinarios.LoadCitasAsync(many.Id);
        }

        var lstVeterinarioDto = mapper.Map<List<VeterinarioxManyDto>>(veterinarios.registros);

        return new Pager<VeterinarioxManyDto>(lstVeterinarioDto, veterinarios.totalRegistros, veterinarioParams.PageIndex, veterinarioParams.PageSize, veterinarioParams.Search);
    }

    [HttpGet("cirujanosVasculares")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> VeterinariosCirujanosVasculares()
    {
        var cirujanosVasculares = await unitOfWork.Veterinarios.VeterinariosCirujanosVasculares();
        return mapper.Map<List<VeterinarioDto>>(cirujanosVasculares);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> Post(VeterinarioDto veterinarioDto)
    {
        var veterinario = mapper.Map<Veterinario>(veterinarioDto);
        unitOfWork.Veterinarios.Add(veterinario);
        await unitOfWork.SaveAsync();
        if (veterinario == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post), new { id = veterinarioDto.Id }, veterinarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Put(string id, [FromBody] VeterinarioDto veterinarioDto)
    {
        if (veterinarioDto == null)
        {
            return NotFound();
        }
        var veterinario = mapper.Map<Veterinario>(veterinarioDto);
        unitOfWork.Veterinarios.Update(veterinario);
        await unitOfWork.SaveAsync();
        return veterinarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var veterinario = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (veterinario == null)
        {
            return NotFound();
        }
        unitOfWork.Veterinarios.Remove(veterinario);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}