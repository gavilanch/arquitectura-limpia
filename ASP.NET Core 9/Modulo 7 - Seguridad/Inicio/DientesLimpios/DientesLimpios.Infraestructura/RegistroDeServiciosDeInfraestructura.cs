using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Infraestructura.Notificaciones;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Infraestructura
{
    public static class RegistroDeServiciosDeInfraestructura
    {
        public static IServiceCollection AgregarServiciosDeInfraestructura(this IServiceCollection services)
        {
            services.AddScoped<IServicioNotificaciones, ServicioCorreos>();
            return services;
        }
    }
}
