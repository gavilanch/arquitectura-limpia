using DientesLimpios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita
{
    public static class MapeadorExtensions
    {
        public static CitaDetalleDTO ADto(this Cita cita)
        {
            var dto = new CitaDetalleDTO
            {
                Id = cita.Id,
                FechaInicio = cita.IntervaloDeTiempo.Inicio,
                FechaFin = cita.IntervaloDeTiempo.Fin,
                Consultorio = cita.Consultorio!.Nombre,
                Dentista = cita.Dentista!.Nombre,
                Paciente = cita.Paciente!.Nombre,
                EstadoCita = cita.Estado.ToString()
            };
            return dto;
        }

    }
}
