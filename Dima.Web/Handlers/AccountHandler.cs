using Dima.Core.Handlers;
using Dima.Core.Requests;
using Dima.Core.Requests.Account;
using Dima.Core.Responses;
using System.Net.Http.Json;
using System.Text;

namespace Dima.Web.Handlers
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHanlder
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Login realizado com sucesso", 200, "Login realizado com sucesso")
                : new Response<string>(null, 400, "Não foi possível realizar o Login");
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("v1/identity/logout", emptyContent);
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/regoster", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Usuario cadastro com sucesso", 201, "Usuario cadastro com sucesso")
                : new Response<string>(null, 400, "Não foi possível realizar o seu cadastro");
        }
    }
}
