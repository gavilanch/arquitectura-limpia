using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;
using DientesLimpios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioDentista : IRepositorio<Dentista>
    {
        Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroDentistasDTO filtro);
    }
}
