using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad Estudiante.
    /// </summary>
    public interface IEstudianteRepository
    {
        /// <summary>Obtiene todos los estudiantes registrados.</summary>
        Task<IEnumerable<Estudiante>> ObtenerTodoAsync();

        /// <summary>Obtiene un estudiante por su identificador único.</summary>
        Task<Estudiante?> ObtenerPorIdAsync(int id);

        /// <summary>Agrega un nuevo estudiante al sistema.</summary>
        Task AgregarAsync(Estudiante estudiante);
    }
}
