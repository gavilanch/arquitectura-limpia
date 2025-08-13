using DientesLimpios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos
{
    public class FiltroCitasDTO
    {
        public Guid? PacienteId { get; set; }
        public Guid? DentistaId { get; set; }
        public Guid? ConsultorioId { get; set; }
        public EstadoCita? EstadoCita { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
