using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages
{
    public interface IService
    {
        Task<string> GetCurrentUserName();
    }

    public class Service : IService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public Service(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<string> GetCurrentUserName()
        {
            var result = await _httpClient.GetStringAsync("api/Account/GetCurrentUserName");
            return result;
        }
    }
}