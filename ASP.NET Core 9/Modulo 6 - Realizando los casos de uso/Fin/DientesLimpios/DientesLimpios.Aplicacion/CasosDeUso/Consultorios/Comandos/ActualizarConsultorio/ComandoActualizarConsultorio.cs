using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio
{
    public class ComandoActualizarConsultorio: IRequest
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
    }
}
