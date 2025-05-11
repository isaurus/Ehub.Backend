using eHub.Backend.Domain.Models;
using FluentValidation;

namespace eHub.Backend.Application.Features.User.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("El apellido de usuario es obligatorio.")
                .MaximumLength(255).WithMessage("Máximo 255 caracteres");

            RuleFor(u => u.Email)   // INVESTIGAR
                .EmailAddress();

            // PONER RESTO DE REGLAS
        }
    }
}
