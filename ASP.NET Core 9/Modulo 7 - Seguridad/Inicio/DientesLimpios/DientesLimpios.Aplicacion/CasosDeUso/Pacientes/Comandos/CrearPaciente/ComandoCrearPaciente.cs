using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente
{
    public class ComandoCrearPaciente: IRequest<Guid>
    {
        public required string Nombre { get; set; }
        public required string Email { get; set; }
    }
}
