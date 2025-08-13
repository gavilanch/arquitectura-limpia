using DientesLimpios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas
{
    public static class MapeadorExtensions
    {
        public static DentistaListadoDTO ADto(this Dentista Dentista)
        {
            var dto = new DentistaListadoDTO { Id = Dentista.Id, Nombre = Dentista.Nombre, Email = Dentista.Email.Valor };
            return dto;
        }
    }
}
