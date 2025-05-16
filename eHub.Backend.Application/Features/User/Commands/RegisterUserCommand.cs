using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class RegisterUserCommand(RegisterUserModel model) : IRequest<OkResponseModel>
    {
        public RegisterUserModel Model { get; set; } = model;
    }
}
