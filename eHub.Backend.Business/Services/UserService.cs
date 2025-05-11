using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using MediatR;

namespace eHub.Backend.Business.Services
{
    public class UserService : IUserService
    {

        private readonly IMediator _mediator;

        public UserService(IMediator mediator) => _mediator = mediator;

        public Task<OkResponseModel> AddGameAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel?> DeleteGameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseModel>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel?> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel?> UpdateGameAsync(int id, UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
