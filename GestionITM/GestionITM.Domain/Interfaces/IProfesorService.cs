using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    /// <summary>
    /// Define el contrato de negocio para la gestión de profesores.
    /// </summary>
    public interface IProfesorService
    {
        /// <summary>Obtiene todos los profesores como DTOs de lectura.</summary>
        Task<IEnumerable<ProfesorDto>> ObtenerTodoAsync();

        /// <summary>Registra un nuevo profesor aplicando las reglas de negocio.</summary>
        Task AgregarAsync(ProfesorCreateDto dto);
    }
}
