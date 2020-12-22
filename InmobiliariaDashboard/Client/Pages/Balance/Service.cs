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
        Task<IEnumerable<EnterpriseBalanceViewModel>> GetEnterpriseList();
        Task<IEnumerable<MonetaryAgentBalanceViewModel>> GetMonetaryAgentList();
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

        public async Task<IEnumerable<EnterpriseBalanceViewModel>> GetEnterpriseList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EnterpriseBalanceViewModel>>("api/Balance/GetEnterprise");
        }

        public async Task<IEnumerable<MonetaryAgentBalanceViewModel>> GetMonetaryAgentList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MonetaryAgentBalanceViewModel>>("api/Balance/GetMonetaryAgent");
        }
    }
}