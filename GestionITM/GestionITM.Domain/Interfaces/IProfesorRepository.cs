using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad Profesor.
    /// </summary>
    public interface IProfesorRepository
    {
        /// <summary>Obtiene todos los profesores registrados.</summary>
        Task<IEnumerable<Profesor>> ObtenerTodoAsync();

        /// <summary>Agrega un nuevo profesor al sistema.</summary>
        Task AgregarAsync(Profesor profesor);

        /// <summary>Verifica si ya existe un profesor con el email dado.</summary>
        Task<bool> ExisteEmailAsync(string email);
    }
}
