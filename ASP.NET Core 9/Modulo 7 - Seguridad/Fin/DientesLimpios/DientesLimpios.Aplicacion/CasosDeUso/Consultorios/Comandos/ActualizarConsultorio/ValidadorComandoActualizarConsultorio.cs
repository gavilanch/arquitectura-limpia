using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio
{
    public class ValidadorComandoActualizarConsultorio : AbstractValidator<ComandoActualizarConsultorio>
    {
        public ValidadorComandoActualizarConsultorio()
        {
            RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .MaximumLength(150).WithMessage("La lontigud del campo {PropertyName} debe ser menor o igual a {MaxLength}");
        }
    }
}
