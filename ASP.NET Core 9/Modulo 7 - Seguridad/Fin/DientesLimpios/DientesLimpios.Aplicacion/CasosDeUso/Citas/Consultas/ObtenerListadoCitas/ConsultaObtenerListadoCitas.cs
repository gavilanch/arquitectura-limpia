using DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas
{
    public class ConsultaObtenerListadoCitas: FiltroCitasDTO, IRequest<List<CitaListadoDTO>>
    {
    }
}
