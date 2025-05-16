using eHub.Backend.Application.Features.User.Commands;
using eHub.Backend.Application.Features.User.Queries;
using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Business.Services
{
    public class UserService : IUserService
    {

        private readonly IMediator _mediator;

        public UserService(IMediator mediator) => _mediator = mediator;

        public async Task<OkResponseModel> AddUserAsync(UserModel model)
        {
            var userCommand = new CreateUserCommand(model);

            return await _mediator.Send(userCommand, default);
        }

        public async Task<OkResponseModel?> DeleteUserAsync(int id)
        {
            var userCommand = new DeleteUserCommand(id);

            return await _mediator.Send(userCommand, default);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            return await _mediator.Send(new GetAllUsersQuery(), default);
        }

        public async Task<UserResponseModel?> GetUserByIdAsync(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id), default);
        }

        public async Task<OkResponseModel?> UpdateUserAsync(int id, UserModel model)
        {
            var userCommand = new UpdateUserCommand(id, model);

            return await _mediator.Send(userCommand, default);
        }




        public async Task<OkResponseModel> RegisterUserAsync(RegisterUserModel model)
        {
            var userCommand = new RegisterUserCommand(model);

            return await _mediator.Send(userCommand, default);
        }

        public async Task<OkResponseModel> CompleteUserProfileAsync(int id, CompleteUserProfileModel model)
        {
            var userCommand = new CompleteUserProfileCommand(id, model);

            return await _mediator.Send(userCommand, default);
        }

        public async Task<AuthResponseModel?> LoginUserAsync(LoginUserModel model)
        {
            var userCommand = new LoginUserCommand(model);

            return await _mediator.Send(userCommand, default);
        }
    }
}
