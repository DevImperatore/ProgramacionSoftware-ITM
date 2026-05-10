using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    /// <summary>
    /// Define el contrato de negocio para la gestión de profesores.
    /// </summary>
    public interface IProfesorService
    {
        /// <summary>Obtiene todos los profesores como DTOs de lectura.</summary>
        Task<IEnumerable<ProfesorDto>> ObtenerTodosLosProfesoresAsync();

        /// <summary>Obtiene un profesor por su identificador único.</summary>
        Task<ProfesorDto?> ObtenerPorIdAsync(int id);

        /// <summary>Registra un nuevo profesor aplicando las reglas de negocio.</summary>
        Task RegistrarProfesorAsync(ProfesorCreateDto dto);
    }
}
