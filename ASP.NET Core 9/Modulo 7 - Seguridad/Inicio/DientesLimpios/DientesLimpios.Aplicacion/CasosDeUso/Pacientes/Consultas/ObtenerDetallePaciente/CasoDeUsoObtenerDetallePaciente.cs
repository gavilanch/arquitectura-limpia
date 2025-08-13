using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente
{
    public class CasoDeUsoObtenerDetallePaciente : IRequestHandler<ConsultaObtenerDetallePaciente, PacienteDetalleDTO>
    {
        private readonly IRepositorioPacientes repositorio;

        public CasoDeUsoObtenerDetallePaciente(IRepositorioPacientes repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PacienteDetalleDTO> Handle(ConsultaObtenerDetallePaciente request)
        {
            var paciente = await repositorio.ObtenerPorId(request.Id);
            if (paciente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return paciente.ADto();
        }
    }
}
