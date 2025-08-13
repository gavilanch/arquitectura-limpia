namespace DientesLimpios.API.DTOs.Citas
{
    public class CrearCitaDTO
    {
        public Guid PacienteId { get; set; }
        public Guid DentistaId { get; set; }
        public Guid ConsultorioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
