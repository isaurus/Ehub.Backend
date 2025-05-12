namespace eHub.Backend.Domain.Contracts.Services
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}
