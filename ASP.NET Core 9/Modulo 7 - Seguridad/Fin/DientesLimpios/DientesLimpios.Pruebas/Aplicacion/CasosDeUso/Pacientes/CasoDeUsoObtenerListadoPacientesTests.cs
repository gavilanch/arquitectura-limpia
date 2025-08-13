using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Pacientes
{
    [TestClass]
    public class CasoDeUsoObtenerListadoPacientesTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IRepositorioPacientes repositorio;
        private CasoDeUsoObtenerListadoPacientes casoDeUso;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repositorio = Substitute.For<IRepositorioPacientes>();
            casoDeUso = new CasoDeUsoObtenerListadoPacientes(repositorio);
        }

        [TestMethod]
        public async Task Handle_RetornaPacientesPaginadosCorrectamente()
        {
            var pagina = 1;
            var registrosPorPagina = 2;

            var filtroPacienteDTO = new FiltroPacienteDTO { Pagina = pagina, RegistrosPorPagina = registrosPorPagina };

            var paciente1 = new Paciente("Felipe", new Email("felipe@ejemplo.com"));
            var paciente2 = new Paciente("Claudia", new Email("claudia@ejemplo.com"));

            IEnumerable<Paciente> pacientes = new List<Paciente> { paciente1, paciente2 };

            repositorio.ObtenerFiltrado(Arg.Any<FiltroPacienteDTO>()).Returns(Task.FromResult(pacientes));

            repositorio.ObtenerCantitadTotalRegistros().Returns(Task.FromResult(10));

            var request = new ConsultaObtenerListadoPacientes
            {
                Pagina = pagina,
                RegistrosPorPagina = registrosPorPagina
            };

            var resultado = await casoDeUso.Handle(request);

            Assert.AreEqual(10, resultado.Total);
            Assert.AreEqual(2, resultado.Elementos.Count);
            Assert.AreEqual("Felipe", resultado.Elementos[0].Nombre);
            Assert.AreEqual("Claudia", resultado.Elementos[1].Nombre);

        }

        [TestMethod]
        public async Task Handle_CuandoNoHayPacientes_RetornaListaVaciaYTotalCero()
        {
            var pagina = 1;
            var registrosPorPagina = 5;

            var filtroPacienteDTO = new FiltroPacienteDTO { Pagina = pagina, RegistrosPorPagina = registrosPorPagina };

            IEnumerable<Paciente> pacientes = new List<Paciente>();

            repositorio.ObtenerFiltrado(Arg.Any<FiltroPacienteDTO>()).Returns(Task.FromResult(pacientes));

            repositorio.ObtenerCantitadTotalRegistros()
                    .Returns(Task.FromResult(0));

            var request = new ConsultaObtenerListadoPacientes
            {
                Pagina = pagina,
                RegistrosPorPagina = registrosPorPagina
            };

            var resultado = await casoDeUso.Handle(request);

            Assert.AreEqual(0, resultado.Total);
            Assert.IsNotNull(resultado.Elementos);
            Assert.AreEqual(0, resultado.Elementos.Count);
        }
    }
}
