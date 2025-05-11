using eHub.Backend.Domain.Models;

namespace eHub.Backend.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseModel>> GetAllGamesAsync();
        Task<UserResponseModel?> GetGameByIdAsync(int id);
        Task<OkResponseModel> AddGameAsync(UserModel model);
        Task<OkResponseModel?> UpdateGameAsync(int id, UserModel model);
        Task<OkResponseModel?> DeleteGameAsync(int id);
    }
}
