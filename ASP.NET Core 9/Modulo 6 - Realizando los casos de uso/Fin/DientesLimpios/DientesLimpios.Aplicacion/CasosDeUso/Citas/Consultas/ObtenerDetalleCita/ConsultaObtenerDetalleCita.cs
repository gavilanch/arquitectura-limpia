using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita
{
    public class ConsultaObtenerDetalleCita: IRequest<CitaDetalleDTO>
    {
        public required Guid Id { get; set; }
    }
}
