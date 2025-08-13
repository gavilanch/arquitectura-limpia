using DientesLimpios.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.ObjetosDeValor
{
    public record IntervaloDeTiempo
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }

        public IntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            if (inicio >= fin)
            {
                throw new ExcepcionDeReglaDeNegocio("La hora de inicio debe ser anterior a la hora de fin.");
            }

            Inicio = inicio;
            Fin = fin;
        }
    }
}
