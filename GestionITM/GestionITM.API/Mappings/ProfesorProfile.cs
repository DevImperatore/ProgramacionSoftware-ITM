using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    /// <summary>
    /// Perfil de AutoMapper para la entidad Profesor.
    /// </summary>
    public class ProfesorProfile : Profile
    {
        public ProfesorProfile()
        {
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorCreateDto, Profesor>();
        }
    }
}
