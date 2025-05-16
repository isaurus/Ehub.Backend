using eHub.Backend.Domain.Enums;

namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de la entidad User para las request.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// El ID único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email del usuario.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña hash del usuario.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// El avatar seleccionado por el usuario.
        /// </summary>
        public string? ProfilePicUrl { get; set; }

        /// <summary>
        /// Nombre del usuario (Máx. 50 caracteres).
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Apellido del usuario (Máx. 255 caracteres).
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Fecha de nacimiento del usuario.
        /// </summary>
        public DateOnly? BirthDate { get; set; }

        /// <summary>
        /// Nacionalidad del usuario.
        /// </summary>
        public Country? Country { get; set; }
    }
}
