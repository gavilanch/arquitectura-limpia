using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita
{
    public class ComandoCrearCita: IRequest<Guid>
    {
        public Guid PacienteId { get; set; }
        public Guid DentistaId { get; set; }
        public Guid ConsultorioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
