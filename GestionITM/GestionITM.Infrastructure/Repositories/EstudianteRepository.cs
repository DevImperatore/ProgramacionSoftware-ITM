using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación en memoria del repositorio de estudiantes.
    /// </summary>
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly List<Estudiante> _estudiantes = new()
        {
            new Estudiante { Id = 1, Nombre = "Thomas Reyes", Correo = "thomasreyesr@gmail.com", Telefono = "6045847613" }
        };

        /// <inheritdoc />
        public Task<IEnumerable<Estudiante>> ObtenerTodoAsync()
        {
            return Task.FromResult<IEnumerable<Estudiante>>(_estudiantes);
        }

        /// <inheritdoc />
        public Task<Estudiante?> ObtenerPorIdAsync(int id)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(estudiante);
        }

        /// <inheritdoc />
        public Task AgregarAsync(Estudiante estudiante)
        {
            estudiante.Id = _estudiantes.Max(e => e.Id) + 1;
            _estudiantes.Add(estudiante);
            return Task.CompletedTask;
        }
    }
}
