using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Aplicacion
{
    public static class RegistroDeServiciosDeAplicacion
    {
        public static IServiceCollection AgregarServiciosDeAplicacion(
                            this IServiceCollection services)
        {
            services.AddTransient<IMediator, MediadorSimple>();

            services.Scan(scan =>
            scan.FromAssembliesOf(typeof(IMediator))
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            
            
            //services.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, 
            //                            CasoDeUsoCrearConsultorio>();
            //services.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, 
            //                    CasoDeUsoObtenerDetalleConsultorio>();

            //services.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, 
            //            List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();

            //services.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();

            //services.AddScoped<IRequestHandler<ComandoBorrarConsultorio>, CasoDeUsoBorrarConsultorio>();

            return services;

        }
    }
}
