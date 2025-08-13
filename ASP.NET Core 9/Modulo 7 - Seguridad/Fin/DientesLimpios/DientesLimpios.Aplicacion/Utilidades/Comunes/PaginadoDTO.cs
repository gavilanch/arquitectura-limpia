using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.Utilidades.Comunes
{
    public class PaginadoDTO<T>
    {
        public List<T> Elementos { get; set; } = [];
        public int Total { get; set; }
    }
}
