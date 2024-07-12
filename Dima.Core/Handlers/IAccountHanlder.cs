using Dima.Core.Requests.Account;
using Dima.Core.Responses;

namespace Dima.Core.Handlers
{
    public interface IAccountHanlder
    {
        Task<Response<string>> LoginAsync(LoginRequest request);
        Task<Response<string>> RegisterAsync(RegisterRequest request);
        Task LogoutAsync();
    }
}
