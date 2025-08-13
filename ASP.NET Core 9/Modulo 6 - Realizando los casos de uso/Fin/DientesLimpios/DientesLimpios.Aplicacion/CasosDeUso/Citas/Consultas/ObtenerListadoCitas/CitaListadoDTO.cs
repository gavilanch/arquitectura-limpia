using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas
{
    public class CitaListadoDTO
    {
        public required Guid Id { get; set; }
        public required string Paciente { get; set; }
        public required string Dentista { get; set; }
        public required string Consultorio { get; set; }
        public required DateTime FechaInicio { get; set; }
        public required DateTime FechaFin { get; set; }
        public required string EstadoCita { get; set; }
    }
}
