
using eHub.Backend.Domain.Models;
using FluentValidation;

namespace eHub.Backend.Application.Features.User.Validators
{
    public class LoginUserModelValidator : AbstractValidator<LoginUserModel>
    {
        public LoginUserModelValidator()
        {
            // Email
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Formato de email inválido")
                .MaximumLength(254).WithMessage("El email no puede exceder 254 caracteres")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Formato de email no válido");

            // PasswordHash (requerido pero no se valida contenido por ser hash)
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria");
        }
    }
}
