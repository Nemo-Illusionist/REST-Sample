using System.Security.Claims;
using System.Threading.Tasks;

namespace Sample.Auth.Contracts
{
    public interface ITokenProvider
    {
        Task<string> Generate(ClaimsIdentity identity);
    }
}