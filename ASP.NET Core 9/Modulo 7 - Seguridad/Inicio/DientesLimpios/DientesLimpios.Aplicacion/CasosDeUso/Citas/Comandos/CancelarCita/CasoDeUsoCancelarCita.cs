using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CancelarCita
{
    public class CasoDeUsoCancelarCita : IRequestHandler<ComandoCancelarCita>
    {
        private readonly IRepositorioCitas repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoCancelarCita(IRepositorioCitas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoCancelarCita request)
        {
            var cita = await repositorio.ObtenerPorId(request.Id);

            if (cita is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            cita.Cancelar();

            try
            {
                await repositorio.Actualizar(cita);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }

        }
    }
}
