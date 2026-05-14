using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.API.Mappings
{
    public class MatriculaProfile : Profile
    {
        public MatriculaProfile()
        {
            CreateMap<Matricula, MatriculaDto>();
            CreateMap<MatriculaCreateDto, Matricula>();
        }
    }
}
