using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client
{
    public class BaseCatalogService<TViewModel> : IBaseCatalogService<TViewModel> where TViewModel : class
    {
        protected string ControllerName;
        protected string DetailControllerName;

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public BaseCatalogService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            ControllerName = "";
            DetailControllerName = "";
        }

        public async Task<IEnumerable<TViewModel>> GetList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TViewModel>>($"api/{ControllerName}");
        }

        public async Task<TViewModel> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}?id={id}");
        }

        public async Task<TViewModel> GetEmpty()
        {
            return await _httpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}/GetEmpty");
        }

        public async Task Add(TViewModel record)
        {
            await _httpClient.PostAsJsonAsync($"api/{ControllerName}", record);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/{ControllerName}?id={id}");
        }

        public async Task Update(TViewModel record)
        {
            await _httpClient.PutAsJsonAsync($"api/{ControllerName}", record);
        }

        public async Task Return()
        {
            _navigationManager.NavigateTo($"{ControllerName.ToLower()}/list");
        }
    }
}