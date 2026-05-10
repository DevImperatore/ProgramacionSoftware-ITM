using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int CursoId { get; set; }

        public DateTime FechaMatricula { get; set; } = DateTime.UtcNow;

        public Estudiante? Estudiante { get; set; }
        public Curso? Curso { get; set; }
    }
}
