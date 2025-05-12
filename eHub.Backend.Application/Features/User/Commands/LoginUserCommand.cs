using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class LoginUserCommand(LoginUserModel model) : IRequest<AuthResponseModel?>
    {
        public LoginUserModel Model { get; set; } = model;
    }
}
