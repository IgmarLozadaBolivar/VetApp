using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // * Veterinario
        CreateMap<Veterinario,VeterinarioDto>().ReverseMap();
        CreateMap<Veterinario,VeterinarioxManyDto>().ReverseMap();

        // * Medicamento
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoxManyDto>().ReverseMap();

        // * Mascota
        CreateMap<Mascota,MascotaDto>().ReverseMap();
        CreateMap<Mascota,MascotaxManyDto>().ReverseMap();
        CreateMap<Mascota, CitaDto>();

        // * Propietario
        CreateMap<Propietario,PropietarioDto>().ReverseMap();
        CreateMap<Propietario,PropietarioxManyDto>().ReverseMap();
        
        // * Cita
        CreateMap<Cita,CitaDto>();
        CreateMap<Cita,CitaxManyDto>();

        // * Especie
        CreateMap<Especie,EspecieDto>();
        CreateMap<Especie,EspeciexManyDto>();

        // * Laboratorio
        CreateMap<Laboratorio,LaboratorioDto>().ReverseMap();
        CreateMap<Laboratorio,LaboratorioxManyDto>().ReverseMap();

        // * Proveedor
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();

        // * Raza
        CreateMap<Raza,RazaDto>().ReverseMap();
        CreateMap<Raza,RazaxManyDto>().ReverseMap();

        // * Tipo Movimiento
        CreateMap<TipoMovimiento,TipoMovimientoDto>().ReverseMap();
        CreateMap<TipoMovimiento,TipoMovimientoxManyDto>().ReverseMap();

        // * Movimiento Medicamento
        CreateMap<MovimientoMedicamento,MovimientoMedicamentoDto>().ReverseMap();
        CreateMap<MovimientoMedicamento,MovimientoMedicamentoxManyDto>().ReverseMap();

        // * Tratamiento Medico
        CreateMap<TratamientoMedico,TratamientoMedicoDto>().ReverseMap();
        CreateMap<TratamientoMedico,TratamientoMedicoxManyDto>().ReverseMap();

        // * User
        CreateMap<User,UserDto>().ReverseMap();

        // * Detalle Movimiento
        CreateMap<DetalleMovimiento,DetalleMovimientoDto>().ReverseMap();
        CreateMap<DetalleMovimiento,DetalleMovimientoxManyDto>().ReverseMap();
    }
}