using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;
using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioCitas : Repositorio<Cita>, IRepositorioCitas
    {
        private readonly DientesLimpiosDbContext context;

        public RepositorioCitas(DientesLimpiosDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin)
        {
            return await context.Citas
                .Where(x => x.DentistaId == dentistaId && x.Estado == Dominio.Enums.EstadoCita.Programada &&
                inicio < x.IntervaloDeTiempo.Fin && fin > x.IntervaloDeTiempo.Inicio
                ).AnyAsync();
        }

        public async Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtroCitasDTO)
        {
            var queryable = context.Citas
                                .Include(x => x.Paciente)
                                .Include(x => x.Dentista)
                                .Include(x => x.Consultorio)
                                .AsQueryable();

            if (filtroCitasDTO.ConsultorioId is not null)
            {
                queryable = queryable.Where(x => x.ConsultorioId == filtroCitasDTO.ConsultorioId);
            }

            if (filtroCitasDTO.DentistaId is not null)
            {
                queryable = queryable.Where(x => x.DentistaId == filtroCitasDTO.DentistaId);
            }

            if (filtroCitasDTO.PacienteId is not null)
            {
                queryable = queryable.Where(x => x.PacienteId == filtroCitasDTO.PacienteId);
            }

            if (filtroCitasDTO.EstadoCita is not null)
            {
                queryable = queryable.Where(x => x.Estado == filtroCitasDTO.EstadoCita);
            }

            return await queryable.Where(x => x.IntervaloDeTiempo.Inicio >= filtroCitasDTO.FechaInicio
            && x.IntervaloDeTiempo.Fin < filtroCitasDTO.FechaFin)
                .OrderBy(x => x.IntervaloDeTiempo.Inicio)
                .ToListAsync();

        }

        new public async Task<Cita?> ObtenerPorId(Guid id)
        {
            return await context.Citas
                .Include(x => x.Paciente)
                .Include(x => x.Dentista)
                .Include(x => x.Consultorio)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
