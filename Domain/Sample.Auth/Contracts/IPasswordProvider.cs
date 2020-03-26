using Sample.Auth.Models;

namespace Sample.Auth.Contracts
{
    public interface IPasswordProvider
    {
        PasswordHash CreatePasswordHash(string password);
        bool VerifyPasswordHash(string password, PasswordHash hash);
    }
}