using eHub.Backend.Domain.Models;

namespace eHub.Backend.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();
        Task<UserResponseModel?> GetUserByIdAsync(int id);
        Task<OkResponseModel> AddUserAsync(UserModel model);
        Task<OkResponseModel?> UpdateUserAsync(int id, UserModel model);
        Task<OkResponseModel?> DeleteUserAsync(int id);
    }
}
