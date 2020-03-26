using System.Threading.Tasks;

namespace Sample.Auth.Contracts
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}