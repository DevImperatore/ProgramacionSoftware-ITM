using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepo;
        private readonly ICursoRepository _cursoRepo;
        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository matriculaRepo, ICursoRepository cursoRepo, IMapper mapper)
        {
            _matriculaRepo = matriculaRepo;
            _cursoRepo = cursoRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatriculaDto>> ObtenerTodasAsync()
        {
            var matriculas = await _matriculaRepo.ObtenerTodoAsync();
            return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
        }

        public async Task<MatriculaDto> MatricularAsync(MatriculaCreateDto dto)
        {
            var curso = await _cursoRepo.ObtenerPorIdAsync(dto.CursoId);
            if (curso is null)
                throw new ArgumentException("El curso no existe.");

            if (curso.CuposDisponibles <= 0)
                throw new ArgumentException("No hay cupos disponibles en este curso.");

            curso.CuposDisponibles--;
            await _cursoRepo.ActualizarAsync(curso);

            var matricula = new Matricula
            {
                EstudianteId = dto.EstudianteId,
                CursoId = dto.CursoId
            };

            var resultado = await _matriculaRepo.CrearAsync(matricula);
            return _mapper.Map<MatriculaDto>(resultado);
        }
    }
}
