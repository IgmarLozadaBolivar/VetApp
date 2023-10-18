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

public class MascotaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var mascotas = await unitOfWork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaDto>>(mascotas);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> Get(string id)
    {
        var mascota = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (mascota == null)
        {
            return NotFound();
        }
        return mapper.Map<MascotaDto>(mascota);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaxManyDto>>> Get11([FromQuery] Params mascotaParams)
    {
        var mascotas = await unitOfWork.Mascotas.GetAllAsync(mascotaParams.PageIndex, mascotaParams.PageSize, mascotaParams.Search);

        foreach (var mascota in mascotas.registros)
        {
            await unitOfWork.Mascotas.LoadPropietariosAsync(mascota);
            await unitOfWork.Mascotas.LoadEspeciesAsync(mascota);
            await unitOfWork.Mascotas.LoadRazasAsync(mascota);
        }

        var lstMascotaDto = mapper.Map<List<MascotaxManyDto>>(mascotas.registros);

        return new Pager<MascotaxManyDto>(lstMascotaDto, mascotas.totalRegistros, mascotaParams.PageIndex, mascotaParams.PageSize, mascotaParams.Search);
    }

    [HttpGet("especieFelina")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> MascotasEspeciesFelinas()
    {
        var especieFelina = await unitOfWork.Mascotas.MascotasEspeciesFelinas();
        return mapper.Map<List<MascotaDto>>(especieFelina);
    }

    [HttpGet("mascotasVacunadasPrimerTrimestre2023")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> MascotasVacunacionPrimerTrimestre2023()
    {
        var mascotasVacunadas = await unitOfWork.Mascotas.MascotasVacunacionPrimerTrimestre2023();
        return mapper.Map<List<MascotaDto>>(mascotasVacunadas);
    }

    [HttpGet("EspeciesMascotas")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> EspeciesMascotas()
    {
        var entidad = await unitOfWork.Mascotas.EspeciesMascotas();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("mascotaAtendidaPorVeterinario")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotaAtendidaPorVeterinario()
    {
        var entidad = await unitOfWork.Mascotas.MascotaAtendidaPorVeterinario();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("razasCantidadMascotas")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> RazasCantidadMascotas()
    {
        var entidad = await unitOfWork.Mascotas.RazasCantidadMascotas();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MascotaDto>> Post(MascotaDto mascotaDto)
    {
        var mascota = mapper.Map<Mascota>(mascotaDto);
        unitOfWork.Mascotas.Add(mascota);
        await unitOfWork.SaveAsync();
        if (mascota == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Put(string id, [FromBody] MascotaDto mascotaDto)
    {
        if (mascotaDto == null)
        {
            return NotFound();
        }
        var mascota = mapper.Map<Mascota>(mascotaDto);
        unitOfWork.Mascotas.Update(mascota);
        await unitOfWork.SaveAsync();
        return mascotaDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var mascota = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (mascota == null)
        {
            return NotFound();
        }
        unitOfWork.Mascotas.Remove(mascota);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}