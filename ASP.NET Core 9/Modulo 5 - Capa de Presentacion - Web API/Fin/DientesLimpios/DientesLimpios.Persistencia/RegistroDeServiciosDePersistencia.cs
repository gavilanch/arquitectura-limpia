using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Persistencia.Repositorios;
using DientesLimpios.Persistencia.UnidadesDeTrabajo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Persistencia
{
    public static class RegistroDeServiciosDePersistencia
    {
        public static IServiceCollection AgregarServiciosDePersistencia(this IServiceCollection services)
        {
            services.AddDbContext<DientesLimpiosDbContext>(options =>
                options.UseSqlServer("name=DientesLimpiosConnectionString"));

            services.AddScoped<IRepositorioConsultorios, RepositorioConsultorios>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoEFCore>();

            return services;
        }
    }
}
