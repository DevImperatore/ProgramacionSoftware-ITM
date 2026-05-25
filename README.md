# Programación de Software — ITM 2026-1

**Thomas Reyes · Tecnología en Desarrollo de Software · Instituto Tecnológico Metropolitano**

[![.NET](https://img.shields.io/badge/.NET_9-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)](https://www.docker.com)
[![MAUI](https://img.shields.io/badge/MAUI-512BD4?style=flat&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/maui/)
[![CI](https://github.com/DevImperatore/ProgramacionSoftware-ITM/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DevImperatore/ProgramacionSoftware-ITM/actions/workflows/dotnet.yml)

Repositorio del curso **Programación de Software (580304006-9)**. Cubre fundamentos de C# orientado a objetos hasta arquitectura limpia con API REST, aplicación móvil y contenedores Docker.

---

## Proyectos

| Carpeta | Proyecto | Descripción |
|---------|----------|-------------|
| `CalculadoraITM/` | Taller 01 | Calculadora robusta con `TryParse` y manejo de división por cero |
| `SistemaNotificaciones/` | TI 01 | Sistema de notificaciones — interfaces, polimorfismo, inyección de dependencias |
| `PagosPolimorfismo/` | TI 02 | Procesador de pagos — herencia, interfaces `IPagoService`, patrones OOP |
| `GestionITM/` | **Taller Final** | API REST en Clean Architecture — ver sección completa abajo |
| `GestionITM.AppMovil/` | **Taller Final (Mobile)** | Aplicación .NET MAUI — cliente móvil de la API |

---

## GestionITM — Sistema de Gestión Académica

Sistema académico completo con arquitectura limpia, API REST autenticada, aplicación móvil y despliegue con Docker.

### Arquitectura

```
GestionITM/
├── GestionITM.API/           ← Capa de presentación: Controllers, Middleware, Program.cs
│   ├── Controllers/          ← AuthController, CursoController, MatriculaController, ProfesorController
│   └── Middleware/           ← ExceptionMiddleware (manejo global de errores)
│
├── GestionITM.Domain/        ← Capa de dominio: Entidades, DTOs, Interfaces (sin dependencias externas)
│   ├── Entities/             ← Curso, Estudiante, Matricula, Profesor
│   ├── Dtos/                 ← DTOs de entrada/salida, PagedResult<T>
│   └── Interfaces/           ← IRepository<T>, IService<T> por entidad
│
├── GestionITM.Infrastructure/ ← Capa de infraestructura: EF Core, Repositorios, Servicios
│   ├── Repositories/         ← Implementaciones de IRepository
│   ├── Services/             ← Implementaciones de IService
│   └── Migrations/           ← EF Core migrations
│
├── GestionITM.Tests/         ← Pruebas unitarias (xUnit)
├── Dockerfile
└── docker-compose.yml

GestionITM.AppMovil/          ← Aplicación .NET MAUI (MVVM)
├── ViewModels/               ← LoginViewModel, CatalogoViewModel
├── Views/                    ← LoginPage, CatalogoPage
└── Services/                 ← ApiService (HTTP client), AuthDelegatingHandler
```

### Stack

- **Backend:** ASP.NET Core Web API (.NET 9) · Entity Framework Core · SQL Server
- **Auth:** JWT Bearer Authentication
- **Mapping:** AutoMapper
- **Docs:** Swagger / OpenAPI
- **Mobile:** .NET MAUI (MVVM pattern)
- **Infra:** Docker + docker-compose
- **Tests:** xUnit
- **CI/CD:** GitHub Actions

### Levantar con Docker

```bash
git clone https://github.com/DevImperatore/ProgramacionSoftware-ITM.git
cd ProgramacionSoftware-ITM/GestionITM
docker-compose up --build
```

La API queda disponible en `http://localhost:8080`. Swagger en `http://localhost:8080/swagger`.

### Levantar sin Docker (desarrollo local)

**Requisitos:** .NET 9 SDK · SQL Server (local o Docker)

```bash
# 1. Configurar connection string en GestionITM.API/appsettings.json

# 2. Aplicar migraciones
cd GestionITM
dotnet ef database update --project GestionITM.Infrastructure --startup-project GestionITM.API

# 3. Ejecutar
dotnet run --project GestionITM.API

# 4. Correr tests
dotnet test GestionITM.Tests
```

### Endpoints principales

| Método | Ruta | Descripción | Auth |
|--------|------|-------------|------|
| `POST` | `/api/auth/login` | Obtener JWT | No |
| `GET` | `/api/cursos` | Listar cursos paginados | Sí |
| `GET` | `/api/profesores` | Listar profesores | Sí |
| `POST` | `/api/matriculas` | Crear matrícula | Sí |
| `GET` | `/api/matriculas` | Listar matrículas | Sí |

> La colección Postman está en `GestionITM_Postman_Collection.json`.

---

## Tecnologías del curso

- .NET 9 / C# 13
- ASP.NET Core Web API
- Entity Framework Core + Code First Migrations
- JWT Bearer Authentication
- AutoMapper
- Swagger / OpenAPI
- .NET MAUI (MVVM)
- Docker + docker-compose
- xUnit (pruebas unitarias)
- GitHub Actions (CI)
