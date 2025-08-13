using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerDetalleDentista
{
    public class CasoDeUsoObtenerDetalleDentista : IRequestHandler<ConsultaObtenerDetalleDentista, DentistaDTO>
    {
        private readonly IRepositorioDentista repositorio;

        public CasoDeUsoObtenerDetalleDentista(IRepositorioDentista repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<DentistaDTO> Handle(ConsultaObtenerDetalleDentista request)
        {
            var dentista = await repositorio.ObtenerPorId(request.Id);
            if (dentista is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return dentista.ADto();
        }
    }
}
