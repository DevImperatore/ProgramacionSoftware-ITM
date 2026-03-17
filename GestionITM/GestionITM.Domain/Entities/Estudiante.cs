using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    /// <summary>
    /// Representa un estudiante dentro del sistema de gestión ITM.
    /// </summary>
    public class Estudiante
    {
        /// <summary>Identificador único del estudiante.</summary>
        public int Id { get; set; }

        /// <summary>Nombre completo del estudiante.</summary>
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>Correo electrónico institucional del estudiante.</summary>
        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        /// <summary>Fecha en que el estudiante fue inscrito.</summary>
        public DateTime FechaInscripcion { get; set; } = DateTime.UtcNow;

        /// <summary>Número de teléfono de contacto.</summary>
        [MaxLength(20)]
        public string? Telefono { get; set; }
    }
}
