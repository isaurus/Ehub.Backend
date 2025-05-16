namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de login de usuario para la request de login.
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// Email del usuario a logear (requerido).
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Contraseña del usuario a logear (requerido).
        /// </summary>
        public required string Password { get; set; }
    }
}
