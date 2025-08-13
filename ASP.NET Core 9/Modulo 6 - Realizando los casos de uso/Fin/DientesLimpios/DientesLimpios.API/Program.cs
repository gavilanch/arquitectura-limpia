using DientesLimpios.API.Jobs;
using DientesLimpios.API.Middlewares;
using DientesLimpios.Aplicacion;
using DientesLimpios.Infraestructura;
using DientesLimpios.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AgregarServiciosDeAplicacion();
builder.Services.AgregarServiciosDePersistencia();
builder.Services.AgregarServiciosDeInfraestructura();

builder.Services.AddHostedService<RecordatorioCitasJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
