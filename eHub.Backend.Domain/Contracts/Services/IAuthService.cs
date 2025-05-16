using eHub.Backend.Domain.Models;

namespace eHub.Backend.Domain.Contracts.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserModel model);
    }
}
