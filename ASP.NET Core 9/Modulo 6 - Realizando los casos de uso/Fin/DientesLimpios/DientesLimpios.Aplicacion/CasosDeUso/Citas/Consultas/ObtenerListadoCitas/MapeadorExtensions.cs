using DientesLimpios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas
{
    public static class MapeadorExtensions
    {
        public static CitaListadoDTO ADto(this Cita cita)
        {
            var dto = new CitaListadoDTO
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
