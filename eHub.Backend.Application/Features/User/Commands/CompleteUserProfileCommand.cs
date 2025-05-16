using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Application.Features.User.Commands
{
    public class CompleteUserProfileCommand(int id, CompleteUserProfileModel model) : IRequest<OkResponseModel>
    {
        public int Id { get; set; } = id;
        public CompleteUserProfileModel Model { get; set; } = model;
    }
}
