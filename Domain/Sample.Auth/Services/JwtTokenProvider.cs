using System.Security.Claims;
using System.Threading.Tasks;
using Sample.Auth.Contracts;

namespace Sample.Auth.Services
{
    public class EmptyTokenProvider : ITokenProvider
    {
        public Task<string> Generate(ClaimsIdentity identity)
        {
            return Task.FromResult(string.Empty);
        }
    }
}