using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Balance
{
    public interface IService
    {
        Task<IEnumerable<BalanceViewModel>> GetList();
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

        public async Task<IEnumerable<BalanceViewModel>> GetList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BalanceViewModel>>("api/Balance");
        }
    }
}