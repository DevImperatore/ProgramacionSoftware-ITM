using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Dtos
{
    public class MatriculaCreateDto
    {
        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int CursoId { get; set; }
    }
}
