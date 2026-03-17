namespace GestionITM.Domain.Dtos
{
    /// <summary>
    /// DTO de lectura para Profesor. No expone FechaContratacion.
    /// </summary>
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
