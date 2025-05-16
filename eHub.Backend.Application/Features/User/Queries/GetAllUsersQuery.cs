using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponseModel>>
    {
    }
}
