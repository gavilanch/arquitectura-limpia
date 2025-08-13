using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class CitaTests
    {
        private Guid _pacienteId = Guid.NewGuid();
        private Guid _dentistaId = Guid.NewGuid();
        private Guid _consultorioId = Guid.NewGuid();
        private IntervaloDeTiempo _intervalo = new IntervaloDeTiempo(DateTime.UtcNow.AddDays(1), 
                                DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_CitaValida_EstadoEsProgramada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);

            Assert.AreEqual(_pacienteId, cita.PacienteId);
            Assert.AreEqual(_dentistaId, cita.DentistaId);
            Assert.AreEqual(_consultorioId, cita.ConsultorioId);
            Assert.AreEqual(_intervalo, cita.IntervaloDeTiempo);
            Assert.AreEqual(EstadoCita.Programada, cita.Estado);
            Assert.AreNotEqual(Guid.Empty, cita.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Constructor_FechaInicioEnElPasado_LanzaExcepcion()
        {
            var intervalo = new IntervaloDeTiempo(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, intervalo);
        }

        [TestMethod]
        public void Cancelar_CitaProgramada_CambiaEstadoACancelada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            Assert.AreEqual(EstadoCita.Cancelada, cita.Estado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Cancelar_CitaNoProgramada_LanzaExcepcion()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            cita.Cancelar();
        }

        [TestMethod]
        public void Completar_CitaProgramada_CambiaEstadoACompletada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Completar();
            Assert.AreEqual(EstadoCita.Completada, cita.Estado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeReglaDeNegocio))]
        public void Completar_CitaCancelada_LanzaExcepcion()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            cita.Completar();
        }
    }
}
