using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class CreateUserCommand(UserModel model) : IRequest<OkResponseModel>
    {
        public UserModel Model { get; set; }
    }
}
