using eHub.Backend.Domain.Enums;

namespace eHub.Backend.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateOnly BirthDate { get; set; }
        // public Country country { get; set; }
        // public string? ProfilePictureUrl { get; set; }

    }
}
