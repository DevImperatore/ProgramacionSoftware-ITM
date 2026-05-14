using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> ObtenerTodoAsync();
        Task<Curso?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Curso curso);
        Task ActualizarAsync(Curso curso);
        Task<PagedResult<Curso>> ObtenerPaginadoAsync(int page, int pageSize);
    }
}
