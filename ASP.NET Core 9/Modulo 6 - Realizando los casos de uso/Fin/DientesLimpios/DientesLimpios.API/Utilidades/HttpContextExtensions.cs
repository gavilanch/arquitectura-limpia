namespace DientesLimpios.API.Utilidades
{
    public static class HttpContextExtensions
    {
        public static void InsertarPaginacionEnCabecera(this HttpContext httpContext, int cantidadTotalRegistros)
        {
            httpContext.Response.Headers.Append("cantidad-total-registros", cantidadTotalRegistros.ToString());
        }
    }
}
