using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class CreateUserCommand(string firstName, string lastName, string email, string passwordHash, DateOnly birthDate) : IRequest<OkResponseModel>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string PasswordHash { get; set; } = passwordHash;
        public DateOnly BirthDate { get; set; } = birthDate;
    }
}
