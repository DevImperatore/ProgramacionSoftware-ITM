using AutoMapper;
using GestionITM.Domain.Dtos;
using GestionITM.Domain.Entities;
using GestionITM.Domain.Interfaces;
using GestionITM.Infrastructure.Services;
using Moq;

namespace GestionITM.Tests
{
    public class MatriculaServiceTests
    {
        private readonly Mock<IMatriculaRepository> _matriculaRepoMock;
        private readonly Mock<ICursoRepository> _cursoRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MatriculaService _service;

        public MatriculaServiceTests()
        {
            _matriculaRepoMock = new Mock<IMatriculaRepository>();
            _cursoRepoMock = new Mock<ICursoRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new MatriculaService(_matriculaRepoMock.Object, _cursoRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task MatricularAsync_CursoNoExiste_LanzaArgumentException()
        {
            _cursoRepoMock.Setup(r => r.ObtenerPorIdAsync(It.IsAny<int>()))
                          .ReturnsAsync((Curso?)null);

            var dto = new MatriculaCreateDto { EstudianteId = 1, CursoId = 99 };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.MatricularAsync(dto));
        }

        [Fact]
        public async Task MatricularAsync_SinCupos_LanzaArgumentException()
        {
            var curso = new Curso { Id = 2, Nombre = "Base de Datos", CuposDisponibles = 0 };
            _cursoRepoMock.Setup(r => r.ObtenerPorIdAsync(2)).ReturnsAsync(curso);

            var dto = new MatriculaCreateDto { EstudianteId = 1, CursoId = 2 };

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _service.MatricularAsync(dto));
            Assert.Contains("cupos", ex.Message);
        }

        [Fact]
        public async Task MatricularAsync_ConCupos_ReduceCuposYCreaMatricula()
        {
            var curso = new Curso { Id = 1, Nombre = "Programacion de Software", CuposDisponibles = 30 };
            var matricula = new Matricula { Id = 1, EstudianteId = 1, CursoId = 1 };
            var matriculaDto = new MatriculaDto { Id = 1, EstudianteId = 1, CursoId = 1 };

            _cursoRepoMock.Setup(r => r.ObtenerPorIdAsync(1)).ReturnsAsync(curso);
            _cursoRepoMock.Setup(r => r.ActualizarAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);
            _matriculaRepoMock.Setup(r => r.CrearAsync(It.IsAny<Matricula>())).ReturnsAsync(matricula);
            _mapperMock.Setup(m => m.Map<MatriculaDto>(matricula)).Returns(matriculaDto);

            var dto = new MatriculaCreateDto { EstudianteId = 1, CursoId = 1 };
            var resultado = await _service.MatricularAsync(dto);

            Assert.NotNull(resultado);
            Assert.Equal(29, curso.CuposDisponibles);
            _cursoRepoMock.Verify(r => r.ActualizarAsync(curso), Times.Once);
            _matriculaRepoMock.Verify(r => r.CrearAsync(It.IsAny<Matricula>()), Times.Once);
        }

        [Fact]
        public async Task ObtenerTodasAsync_RetornaListaDeMatriculas()
        {
            var matriculas = new List<Matricula> { new Matricula { Id = 1, EstudianteId = 1, CursoId = 1 } };
            var dtos = new List<MatriculaDto> { new MatriculaDto { Id = 1, EstudianteId = 1, CursoId = 1 } };

            _matriculaRepoMock.Setup(r => r.ObtenerTodoAsync()).ReturnsAsync(matriculas);
            _mapperMock.Setup(m => m.Map<IEnumerable<MatriculaDto>>(matriculas)).Returns(dtos);

            var resultado = await _service.ObtenerTodasAsync();

            Assert.Single(resultado);
        }
    }
}
