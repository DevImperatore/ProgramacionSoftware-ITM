using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;

namespace GestionITM.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación en memoria del repositorio de cursos.
    /// </summary>
    public class CursoRepository : ICursoRepository
    {
        private readonly List<Curso> _cursos = new()
        {
            new Curso { Id = 1, Nombre = "Programación de Software", Codigo = "580304006", Creditos = 3 },
            new Curso { Id = 2, Nombre = "Base de Datos", Codigo = "580304010", Creditos = 3 }
        };

        /// <inheritdoc />
        public Task<IEnumerable<Curso>> ObtenerTodoAsync()
        {
            return Task.FromResult<IEnumerable<Curso>>(_cursos);
        }

        /// <inheritdoc />
        public Task<Curso?> ObtenerPorIdAsync(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(curso);
        }

        /// <inheritdoc />
        public Task AgregarAsync(Curso curso)
        {
            curso.Id = _cursos.Max(c => c.Id) + 1;
            _cursos.Add(curso);
            return Task.CompletedTask;
        }
    }
}
