using eHub.Backend.Domain.Models;
using FluentValidation;

namespace eHub.Backend.Application.Features.User.Validators
{
    public class CompleteUserProfileModelValidator : AbstractValidator<CompleteUserProfileModel>
    {
        public CompleteUserProfileModelValidator()
        {
            // FirstName (requerido)
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres")
                .Matches(@"^[\p{L}\s'-]*$").WithMessage("Solo se permiten letras, espacios y apóstrofes");

            // LastName (requerido)
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(255).WithMessage("Máximo 255 caracteres")
                .Matches(@"^[\p{L}\s'-]*$").WithMessage("Solo se permiten letras, espacios y apóstrofes");

            // ProfilePicUrl (requerido)
            RuleFor(u => u.ProfilePicUrl)
                .NotEmpty().WithMessage("La URL del avatar es obligatoria")
                .MaximumLength(2048).WithMessage("La URL no puede exceder 2048 caracteres")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("La URL del avatar no es válida");

            // BirthDate (requerido)
            RuleFor(u => u.BirthDate)
                .NotEmpty().WithMessage("La URL del avatar es obligatoria")
                .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha de nacimiento no puede ser futura")
                .Must(date => date.Year > 1900).WithMessage("La fecha de nacimiento debe ser posterior a 1900")
                .Must(date => (DateTime.Today.Year - date.Year) >= 13).WithMessage("El usuario debe tener al menos 13 años");

            // Country (requerido, enum)
            RuleFor(u => u.Country)
                .IsInEnum().WithMessage("País no válido");
        }
    }
}
