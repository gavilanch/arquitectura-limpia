using DientesLimpios.API.DTOs.Citas;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CancelarCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CompletarCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerDetalleCita;
using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitasController: ControllerBase
    {
        private readonly IMediator mediator;

        public CitasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CitaListadoDTO>>> Get([FromQuery] ConsultaObtenerListadoCitas consulta)
        {
            var resultado = await mediator.Send(consulta);
            return resultado;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitaDetalleDTO>> Get(Guid id)
        {
            var consulta = new ConsultaObtenerDetalleCita { Id = id };
            var resultado = await mediator.Send(consulta);
            return resultado;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CrearCitaDTO crearCitaDTO)
        {
            var comando = new ComandoCrearCita
            {
                ConsultorioId = crearCitaDTO.ConsultorioId,
                DentistaId = crearCitaDTO.DentistaId,
                PacienteId = crearCitaDTO.PacienteId,
                FechaInicio = crearCitaDTO.FechaInicio,
                FechaFin = crearCitaDTO.FechaFin
            };

            var resultado = await mediator.Send(comando);
            return Ok();
        }

        [HttpPost("{id}/completar")]
        public async Task<IActionResult> Completar(Guid id)
        {
            var consulta = new ComandoCompletarCita { Id = id };
            await mediator.Send(consulta);
            return Ok();
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            var consulta = new ComandoCancelarCita { Id = id };
            await mediator.Send(consulta);
            return Ok();
        }


    }
}
