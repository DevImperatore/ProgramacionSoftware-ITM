using GestionITM.Domain.Dtos;
using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var matriculas = await _service.ObtenerTodasAsync();
            return Ok(matriculas);
        }

        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        public async Task<IActionResult> Post([FromBody] MatriculaCreateDto dto)
        {
            var matricula = await _service.MatricularAsync(dto);
            return Created(string.Empty, matricula);
        }
    }
}
