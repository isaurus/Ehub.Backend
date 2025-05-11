namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de datos devueltos para usuarios
    /// </summary>
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string BirthDate {  get; set; } = string.Empty;
    }
}
