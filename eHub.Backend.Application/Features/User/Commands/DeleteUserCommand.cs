using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class DeleteUserCommand(int id) : IRequest<OkResponseModel>
    {
        public int Id { get; set; } = id;
    }
}
