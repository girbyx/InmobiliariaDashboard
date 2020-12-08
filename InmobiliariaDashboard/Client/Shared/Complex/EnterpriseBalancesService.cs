using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Shared.Complex
{
    public interface IEnterpriseBalancesService
    {
        Task<IEnumerable<BalanceViewModel>> GetList();
    }

    public class EnterpriseBalancesService : IEnterpriseBalancesService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public EnterpriseBalancesService(HttpClient httpClient, NavigationManager navigationManager)
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