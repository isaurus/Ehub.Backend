namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de datos para usuario
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Nombre del usuario (Máx. 50 caracteres).
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Apellido del usuario (Máx. 255 caracteres).
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email del usuario.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña hash del usuario.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de nacimiento del usuario.
        /// </summary>
        public DateOnly BirtDate { get; set; }
    }
}
