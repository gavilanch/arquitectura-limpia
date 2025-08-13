using DientesLimpios.API.DTOs.Dentistas;
using DientesLimpios.API.Utilidades;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.ActualizarDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.BorrarDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.CrearDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerDetalleDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/Dentistas")]
    public class DentistasController : ControllerBase
    {
        private readonly IMediator mediator;

        public DentistasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DentistaListadoDTO>>> Get(
            [FromQuery] ConsultaObtenerListadoDentistas consulta)
        {
            var resultado = await mediator.Send(consulta);
            HttpContext.InsertarPaginacionEnCabecera(resultado.Total);
            return resultado.Elementos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentistaDTO>> Get(Guid id)
        {
            var consulta = new ConsultaObtenerDetalleDentista() { Id = id };
            var resultado = await mediator.Send(consulta);
            return resultado;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CrearDentistaDTO crearDentistaDTO)
        {
            var comando = new ComandoCrearDentista { Nombre = crearDentistaDTO.Nombre, Email = crearDentistaDTO.Email };
            await mediator.Send(comando);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CrearDentistaDTO crearDentistaDTO)
        {
            var comando = new ComandoActualizarDentista { Id = id, Nombre = crearDentistaDTO.Nombre, Email = crearDentistaDTO.Email };
            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comando = new ComandoBorrarDentista { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
