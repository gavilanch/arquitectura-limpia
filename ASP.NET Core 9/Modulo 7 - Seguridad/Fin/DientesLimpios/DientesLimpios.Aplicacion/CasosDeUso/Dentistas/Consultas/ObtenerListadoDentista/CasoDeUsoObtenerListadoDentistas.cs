using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Comunes;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas
{
    public class CasoDeUsoObtenerListadoDentistas : IRequestHandler<ConsultaObtenerListadoDentistas, PaginadoDTO<DentistaListadoDTO>>
    {
        private readonly IRepositorioDentista repositorio;

        public CasoDeUsoObtenerListadoDentistas(IRepositorioDentista repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PaginadoDTO<DentistaListadoDTO>> Handle(ConsultaObtenerListadoDentistas request)
        {
            var Dentistas = await repositorio.ObtenerFiltrado(request);
            var totalDentistas = await repositorio.ObtenerCantitadTotalRegistros();
            var DentistasDTO = Dentistas.Select(dentista => dentista.ADto()).ToList();

            var paginadoDTO = new PaginadoDTO<DentistaListadoDTO>
            {
                Elementos = DentistasDTO,
                Total = totalDentistas
            };

            return paginadoDTO;
        }
    }
}
