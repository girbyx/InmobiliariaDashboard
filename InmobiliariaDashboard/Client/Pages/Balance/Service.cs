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
        Task<IEnumerable<PeopleBalanceViewModel>> GetEnterpriseList();
        Task<IEnumerable<BankAccountBalanceViewModel>> GetMonetaryAgentList();
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

        public async Task<IEnumerable<PeopleBalanceViewModel>> GetEnterpriseList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PeopleBalanceViewModel>>("api/Balance/GetEnterprise");
        }

        public async Task<IEnumerable<BankAccountBalanceViewModel>> GetMonetaryAgentList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BankAccountBalanceViewModel>>("api/Balance/GetMonetaryAgent");
        }
    }
}