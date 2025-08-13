using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public class ConsultaObtenerDetalleConsultorio: IRequest<ConsultorioDetalleDTO>
    {
        public Guid Id { get; set; }
    }
}
