using DientesLimpios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public static class MapeadorExtensions
    {
        public static ConsultorioDetalleDTO ADto(this Consultorio consultorio)
        {
            var dto = new ConsultorioDetalleDTO { Id = consultorio.Id, Nombre = consultorio.Nombre };
            return dto;
        }
    }
}
