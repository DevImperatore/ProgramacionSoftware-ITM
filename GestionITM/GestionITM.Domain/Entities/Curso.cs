using System.ComponentModel.DataAnnotations;

namespace GestionITM.Domain.Entities
{
    /// <summary>
    /// Representa un curso académico dentro del sistema de gestión ITM.
    /// </summary>
    public class Curso
    {
        /// <summary>Identificador único del curso.</summary>
        public int Id { get; set; }

        /// <summary>Nombre del curso.</summary>
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>Código único del curso.</summary>
        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } = string.Empty;

        /// <summary>Número de créditos académicos del curso.</summary>
        public int Creditos { get; set; }
    }
}
