using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<Matricula>> ObtenerTodoAsync();
        Task<Matricula?> ObtenerPorIdAsync(int id);
        Task<Matricula> CrearAsync(Matricula matricula);
    }
}
