using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    /// <summary>
    /// Controlador para la gestión de profesores.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _service;

        public ProfesorController(IProfesorService service)
        {
            _service = service;
        }

        /// <summary>Obtiene la lista de todos los profesores.</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profesores = await _service.ObtenerTodosLosProfesoresAsync();
            return Ok(profesores);
        }

        /// <summary>Obtiene un profesor por su ID.</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profesor = await _service.ObtenerPorIdAsync(id);
            if (profesor is null) return NotFound();
            return Ok(profesor);
        }

        /// <summary>Registra un nuevo profesor en el sistema.</summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfesorCreateDto dto)
        {
            await _service.RegistrarProfesorAsync(dto);
            return Created(string.Empty, null);
        }
    }
}
