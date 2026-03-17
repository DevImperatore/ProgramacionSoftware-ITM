using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad Curso.
    /// </summary>
    public interface ICursoRepository
    {
        /// <summary>Obtiene todos los cursos registrados.</summary>
        Task<IEnumerable<Curso>> ObtenerTodoAsync();

        /// <summary>Obtiene un curso por su identificador único.</summary>
        Task<Curso?> ObtenerPorIdAsync(int id);

        /// <summary>Agrega un nuevo curso al sistema.</summary>
        Task AgregarAsync(Curso curso);
    }
}
