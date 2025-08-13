using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.BorrarPaciente
{
    public class CasoDeUsoBorrarPaciente : IRequestHandler<ComandoBorrarPaciente>
    {
        private readonly IRepositorioPacientes repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoBorrarPaciente(IRepositorioPacientes repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoBorrarPaciente request)
        {
            var paciente = await repositorio.ObtenerPorId(request.Id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            try
            {
                await repositorio.Borrar(paciente);
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
