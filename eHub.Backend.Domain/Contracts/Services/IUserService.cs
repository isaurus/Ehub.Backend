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


        Task<OkResponseModel> RegisterUserAsync(RegisterUserModel model);     // Para registro de nuevos usuarios desde la app
        Task<OkResponseModel> CompleteUserProfileAsync(int id, CompleteUserProfileModel model);    // Para el segundo paso de registro de usuarios desde la app
    }
}
