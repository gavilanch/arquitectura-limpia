using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.BorrarDentista
{
    public class ComandoBorrarDentista : IRequest
    {
        public Guid Id { get; set; }
    }
}
