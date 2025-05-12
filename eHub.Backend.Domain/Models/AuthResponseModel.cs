namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de respuesta devuelto para el usuario autenticado.
    /// </summary>
    public class AuthResponseModel
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
    }
}
