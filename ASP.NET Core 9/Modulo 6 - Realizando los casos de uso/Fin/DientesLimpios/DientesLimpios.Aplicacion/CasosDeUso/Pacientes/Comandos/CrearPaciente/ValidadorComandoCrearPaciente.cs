using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente
{
    public class ValidadorComandoCrearPaciente : AbstractValidator<ComandoCrearPaciente>
    {
        public ValidadorComandoCrearPaciente()
        {
            RuleFor(p => p.Nombre)
        .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
        .MaximumLength(250).WithMessage("La lontigud del campo {PropertyName} debe ser menor o igual a {MaxLength}");

            RuleFor(p => p.Email)
    .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
    .MaximumLength(254).WithMessage("La lontigud del campo {PropertyName} debe ser menor o igual a {MaxLength}")
    .EmailAddress().WithMessage("El formato del email no es válido");

        }
    }
}
