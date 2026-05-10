using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } = string.Empty;

        public int Creditos { get; set; }

        public int CuposDisponibles { get; set; }
    }
}
