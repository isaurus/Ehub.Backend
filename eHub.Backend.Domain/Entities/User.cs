using eHub.Backend.Domain.Enums;

namespace eHub.Backend.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public string? ProfilePicUrl { get; set; }
        public string? FirstName {  get; set; }
        public string? LastName {  get; set; }
        public DateOnly? BirthDate { get; set; }
        public Country? Country { get; set; }

    }
}
