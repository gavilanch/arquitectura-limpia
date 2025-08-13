using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCitas
{
    public class CasoDeUsoComandoEnviarRecordatorioCitas : IRequestHandler<ComandoEnviarRecordatorioCitas>
    {
        private readonly IRepositorioCitas repositorio;
        private readonly IServicioNotificaciones servicioNotificaciones;

        public CasoDeUsoComandoEnviarRecordatorioCitas(IRepositorioCitas repositorio,
                IServicioNotificaciones servicioNotificaciones)
        {
            this.repositorio = repositorio;
            this.servicioNotificaciones = servicioNotificaciones;
        }

        public async Task Handle(ComandoEnviarRecordatorioCitas request)
        {
            var mañana = DateTime.UtcNow.Date.AddDays(1);
            var fechaInicio = mañana;
            var fechaFin = mañana.AddDays(1);
            var filtro = new FiltroCitasDTO
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                EstadoCita = EstadoCita.Programada
            };

            var citas = await repositorio.ObtenerFiltrado(filtro);
            foreach (var cita in citas)
            {
                var citaDTO = cita.ADto();
                await servicioNotificaciones.EnviarRecordatorioCita(citaDTO);
            }

        }
    }
}
