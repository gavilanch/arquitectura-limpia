using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Dominio.Excepciones;
using System.Net;
using System.Text.Json;

namespace DientesLimpios.API.Middlewares
{
    public class ManejadorExcepcionesMiddleware
    {
        private readonly RequestDelegate _next;

        public ManejadorExcepcionesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepcion(context, ex);
            }
        }

        private Task ManejarExcepcion(HttpContext context, Exception excepcion)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var resultado = string.Empty;

            switch (excepcion)
            {
                case ExcepcionNoEncontrado:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ExcepcionDeValidacion excepcionDeValidacion:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(excepcionDeValidacion.ErroresDeValidacion);
                    break;
                case ExcepcionDeReglaDeNegocio excepcionReglaDeNegocio:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(excepcionReglaDeNegocio.Message);
                    break;

            }

            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(resultado);
        }
    }

    public static class ManejadorExcepcionesMiddlewareExtensions
    {
        public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ManejadorExcepcionesMiddleware>();
        }
    }

}
