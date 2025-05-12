using eHub.Backend.Domain.Models;
using FluentValidation;

namespace eHub.Backend.Application.Features.User.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            // Email
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Formato de email inválido")
                .MaximumLength(254).WithMessage("El email no puede exceder 254 caracteres")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Formato de email no válido");

            // PasswordHash (requerido pero no se valida contenido por ser hash)
            RuleFor(u => u.PasswordHash)
                .NotEmpty().WithMessage("El hash de contraseña es obligatorio");

            // FirstName (opcional)
            When(u => !string.IsNullOrWhiteSpace(u.FirstName), () =>
            {
                RuleFor(u => u.FirstName)
                    .MaximumLength(50).WithMessage("Máximo 50 caracteres")
                    .Matches(@"^[\p{L}\s'-]*$").WithMessage("Solo se permiten letras, espacios y apóstrofes");
            });

            // LastName (opcional)
            When(u => !string.IsNullOrWhiteSpace(u.LastName), () =>
            {
                RuleFor(u => u.LastName)
                    .MaximumLength(255).WithMessage("Máximo 255 caracteres")
                    .Matches(@"^[\p{L}\s'-]*$").WithMessage("Solo se permiten letras, espacios y apóstrofes");
            });

            // ProfilePicUrl (opcional)
            When(u => !string.IsNullOrWhiteSpace(u.ProfilePicUrl), () =>
            {
                RuleFor(u => u.ProfilePicUrl)
                    .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                    .WithMessage("La URL del avatar no es válida")
                    .MaximumLength(2048).WithMessage("La URL no puede exceder 2048 caracteres");
            });

            // BirthDate (opcional)
            When(u => u.BirthDate.HasValue, () =>
            {
                RuleFor(u => u.BirthDate.Value)
                    .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha de nacimiento no puede ser futura")
                    .Must(date => date.Year > 1900).WithMessage("La fecha de nacimiento debe ser posterior a 1900")
                    .Must(date => (DateTime.Today.Year - date.Year) >= 13).WithMessage("El usuario debe tener al menos 13 años");
            });

            // Country (opcional)
            When(u => u.Country.HasValue, () =>
            {
                RuleFor(u => u.Country.Value)
                    .IsInEnum().WithMessage("País no válido");
            });
        }
    }
}
