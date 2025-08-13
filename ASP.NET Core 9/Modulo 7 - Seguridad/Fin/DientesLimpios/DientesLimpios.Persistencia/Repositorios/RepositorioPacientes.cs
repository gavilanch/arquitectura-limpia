using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Persistencia.Repositorios
{
    public class RepositorioPacientes : Repositorio<Paciente>, IRepositorioPacientes
    {
        private readonly DientesLimpiosDbContext context;

        public RepositorioPacientes(DientesLimpiosDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Paciente>> ObtenerFiltrado(FiltroPacienteDTO filtro)
        {
            var queryable = context.Pacientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                queryable = queryable.Where(x => x.Nombre.Contains(filtro.Nombre));
            }

            if (!string.IsNullOrWhiteSpace(filtro.Email))
            {
                queryable = queryable.Where(x => x.Email.Valor.Contains(filtro.Email));
            }


            return await queryable.OrderBy(x => x.Nombre)
                .Paginar(filtro.Pagina, filtro.RegistrosPorPagina).ToListAsync();
        }
    }
}
