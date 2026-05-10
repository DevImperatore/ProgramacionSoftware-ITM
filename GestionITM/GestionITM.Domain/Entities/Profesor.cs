using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    /// <summary>
    /// Representa un profesor dentro del sistema de gestión ITM.
    /// </summary>
    public class Profesor
    {
        /// <summary>Identificador único del profesor.</summary>
        public int Id { get; set; }

        /// <summary>Nombre completo del profesor.</summary>
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>Área de especialización del profesor.</summary>
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>Correo electrónico institucional del profesor.</summary>
        [Required]
        public string Email { get; set; } = string.Empty;

        /// <summary>Fecha en que fue contratado el profesor.</summary>
        public DateTime FechaContratacion { get; set; }
    }
}
