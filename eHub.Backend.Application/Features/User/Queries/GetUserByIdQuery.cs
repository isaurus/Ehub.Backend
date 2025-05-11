using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Queries
{
    public class GetUserByIdQuery(int id) : IRequest<UserResponseModel?>
    {
        public int Id { get; set; } = id;
    }
}
