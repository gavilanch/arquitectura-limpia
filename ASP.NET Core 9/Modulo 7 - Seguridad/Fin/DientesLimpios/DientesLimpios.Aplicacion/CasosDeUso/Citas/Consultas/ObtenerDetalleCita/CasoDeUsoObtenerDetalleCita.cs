using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita
{
    public class CasoDeUsoObtenerDetalleCita : IRequestHandler<ConsultaObtenerDetalleCita, CitaDetalleDTO>
    {
        private readonly IRepositorioCitas repositorio;

        public CasoDeUsoObtenerDetalleCita(IRepositorioCitas repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<CitaDetalleDTO> Handle(ConsultaObtenerDetalleCita request)
        {
            var cita = await repositorio.ObtenerPorId(request.Id);

            if (cita is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return cita.ADto();
        }
    }
}
