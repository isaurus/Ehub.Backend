using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class LoginUserCommand(int id, LoginUserModel model) : IRequest<OkResponseModel?>
    {
        public int Id { get; set; } = id;
        public LoginUserModel Model { get; set; } = model;
    }
}
