using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Login
{
    public interface IService
    {
        Task<HttpStatusCode> Login(LoginUserViewModel record);
        Task Logout();
        Task GoBackHome();
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

        public async Task<HttpStatusCode> Login(LoginUserViewModel record)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Account/Login", record);
            return result.StatusCode;
        }

        public async Task Logout()
        {
            await _httpClient.GetAsync("api/Account/Logout");
        }

        public async Task GoBackHome()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}