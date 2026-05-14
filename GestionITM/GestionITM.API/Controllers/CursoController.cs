using GestionITM.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionITM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _repo;

        public CursoController(ICursoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _repo.ObtenerTodoAsync();
            return Ok(cursos);
        }

        [HttpGet("paginado")]
        [Authorize]
        public async Task<IActionResult> GetPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _repo.ObtenerPaginadoAsync(page, pageSize);
            return Ok(resultado);
        }
    }
}
