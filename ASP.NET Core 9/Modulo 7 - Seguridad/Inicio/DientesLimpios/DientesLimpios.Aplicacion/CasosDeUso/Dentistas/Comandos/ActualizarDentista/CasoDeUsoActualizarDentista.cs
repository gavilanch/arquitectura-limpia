using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.ActualizarDentista
{
    public class CasoDeUsoActualizarDentista : IRequestHandler<ComandoActualizarDentista>
    {
        private readonly IRepositorioDentista repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarDentista(IRepositorioDentista repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarDentista peticion)
        {
            var dentista = await repositorio.ObtenerPorId(peticion.Id);

            if (dentista is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            dentista.ActualizarNombre(peticion.Nombre);
            var email = new Email(peticion.Email);
            dentista.ActualizarEmail(email);

            try
            {
                await repositorio.Actualizar(dentista);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
