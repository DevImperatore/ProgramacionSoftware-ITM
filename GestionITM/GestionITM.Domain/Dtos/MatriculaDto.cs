namespace GestionITM.Domain.Dtos
{
    public class MatriculaDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaMatricula { get; set; }
    }
}
