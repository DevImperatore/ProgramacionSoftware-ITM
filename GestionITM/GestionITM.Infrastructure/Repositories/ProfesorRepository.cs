using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionITM.Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de profesores usando Entity Framework Core.
    /// </summary>
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Profesor>> ObtenerTodoAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        /// <inheritdoc />
        public async Task AgregarAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Profesores.AnyAsync(p => p.Email == email);
        }
    }
}
