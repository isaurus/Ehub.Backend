namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de respuesta para las consultas sobre la DB (Queries).
    /// </summary>
    public class UserResponseModel
    {
        /// <summary>
        /// El ID del usuario solicitado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// El correo del usuario solicitado.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// La contrasña (hash) del usuario solicitado. -> CREO QUE ESTO NO DEBERÍA IR AQUÍ
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// El avatar del usuario solicitado.
        /// </summary>
        public string ProfilePicUrl { get; set; } = string.Empty;

        /// <summary>
        /// El nombre del usuario solicitdo.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Los apellidos del usuario solicitado.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// La fecha de nacimiento del usuario solicitado.
        /// </summary>
        public string BirthDate {  get; set; } = string.Empty;
        /// <summary>
        /// La nacionalidad del usuario solicitado.
        /// </summary>
        public string Country {  get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del usuario.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha de actualización del usuario.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
