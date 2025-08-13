using DientesLimpios.API.Jobs;
using DientesLimpios.API.Middlewares;
using DientesLimpios.Aplicacion;
using DientesLimpios.Infraestructura;
using DientesLimpios.Persistencia;
using DientesLimpios.Identidad;
using DientesLimpios.Identidad.Modelos;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter("esadmin"));
});

builder.Services.AgregarServiciosDeAplicacion();
builder.Services.AgregarServiciosDePersistencia();
builder.Services.AgregarServiciosDeInfraestructura();
builder.Services.AgregarServiciosDeIdentidad();

builder.Services.AddHostedService<RecordatorioCitasJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapIdentityApi<Usuario>();

app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
