using System.Net;
using System.Text.Json;

namespace GestionITM.API.Middleware
{
    /// <summary>
    /// Middleware global para capturar excepciones no controladas y devolver JSON estandarizado.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                await EscribirRespuesta(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                await EscribirRespuesta(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                await EscribirRespuesta(context, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private static async Task EscribirRespuesta(HttpContext context, HttpStatusCode codigo, string mensaje)
        {
            context.Response.StatusCode = (int)codigo;
            context.Response.ContentType = "application/json";

            var respuesta = new
            {
                status = (int)codigo,
                error = codigo.ToString(),
                message = mensaje,
                timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(respuesta));
        }
    }
}
