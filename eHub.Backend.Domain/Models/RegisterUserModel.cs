namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de registro de usuario para la request de registro.
    /// </summary>
    public class RegisterUserModel
    {
        /// <summary>
        /// Email del usuario a registrar (requerido).
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Contraseña del usuario a registrar (requerido).
        /// </summary>
        public required string Password { get; set; }
    }
}
