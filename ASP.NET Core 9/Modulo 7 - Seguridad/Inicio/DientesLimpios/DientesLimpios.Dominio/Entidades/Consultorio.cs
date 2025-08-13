﻿using DientesLimpios.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Dominio.Entidades
{
    public class Consultorio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;

        public Consultorio(string nombre)
        {
            AplicarReglasDeNegocioNombre(nombre);

            Nombre = nombre;
            Id = Guid.CreateVersion7();
        }

        public void ActualizarNombre(string nombre)
        {
            AplicarReglasDeNegocioNombre(nombre);

            Nombre = nombre;
        }

        private void AplicarReglasDeNegocioNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }
        }

    }
}
