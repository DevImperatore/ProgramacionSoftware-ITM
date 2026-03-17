using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Services
{
    /// <summary>
    /// Servicio de negocio para la gestión de profesores.
    /// </summary>
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _repository;
        private readonly IMapper _mapper;

        public ProfesorService(IProfesorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProfesorDto>> ObtenerTodoAsync()
        {
            var profesores = await _repository.ObtenerTodoAsync();
            return _mapper.Map<IEnumerable<ProfesorDto>>(profesores);
        }

        /// <inheritdoc />
        public async Task AgregarAsync(ProfesorCreateDto dto)
        {
            // Reto de robustez: provocar error si el nombre es "Error"
            if (dto.Nombre == "Error")
                throw new Exception("Error de prueba");

            // Regla de negocio: especialidad no puede estar vacía
            if (string.IsNullOrWhiteSpace(dto.Especialidad))
                throw new ArgumentException("La especialidad del profesor no puede estar vacía.");

            // Regla de negocio: log de perfil senior
            if (dto.Especialidad.Equals("Arquitectura", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Perfil Senior Detectado");

            // Bonus Nivel 5: email único
            if (await _repository.ExisteEmailAsync(dto.Email))
                throw new InvalidOperationException($"Ya existe un profesor registrado con el email '{dto.Email}'.");

            var profesor = _mapper.Map<Profesor>(dto);
            await _repository.AgregarAsync(profesor);
        }
    }
}
