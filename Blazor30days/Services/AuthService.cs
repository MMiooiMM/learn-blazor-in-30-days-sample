using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor30days.Model;

namespace Blazor30days.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorageService
        )
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<bool> Check()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/auth");

            var token = await _localStorageService.GetItemAsync<string>("token");

            if (token is null)
            {
                return false;
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return false;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}