namespace eHub.Backend.Domain.Contracts.Hash
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}
