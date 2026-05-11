using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Matricula>> ObtenerTodoAsync()
        {
            return await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .ToListAsync();
        }

        public async Task<Matricula?> ObtenerPorIdAsync(int id)
        {
            return await _context.Matriculas
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Matricula> CrearAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }
    }
}
