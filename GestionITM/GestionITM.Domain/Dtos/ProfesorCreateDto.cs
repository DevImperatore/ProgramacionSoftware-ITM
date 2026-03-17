using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Dtos
{
    /// <summary>
    /// DTO de inserción para Profesor.
    /// </summary>
    public class ProfesorCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime FechaContratacion { get; set; }
    }
}
