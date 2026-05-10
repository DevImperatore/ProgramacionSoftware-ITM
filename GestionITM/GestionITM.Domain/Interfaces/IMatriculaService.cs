using GestionITM.Domain.Dtos;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaService
    {
        Task<IEnumerable<MatriculaDto>> ObtenerTodasAsync();
        Task<MatriculaDto> MatricularAsync(MatriculaCreateDto dto);
    }
}
