using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas
{
    public class CasoDeUsoObtenerListadoCitas : IRequestHandler<ConsultaObtenerListadoCitas, List<CitaListadoDTO>>
    {
        private readonly IRepositorioCitas repositorio;

        public CasoDeUsoObtenerListadoCitas(IRepositorioCitas repositorio)
        {
            this.repositorio = repositorio;
        }


        public async Task<List<CitaListadoDTO>> Handle(ConsultaObtenerListadoCitas request)
        {
            var citas = await repositorio.ObtenerFiltrado(request);
            var citasDTO = citas.Select(cita => cita.ADto()).ToList();
            return citasDTO;
        }
    }
}
