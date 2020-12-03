using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public interface IClientService : IBaseService<ClientViewModel>
    {
    }

    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ClientService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<IEnumerable<ClientViewModel>> GetList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClientViewModel>>("api/Client");
        }

        public async Task<ClientViewModel> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClientViewModel>($"api/ClientDetail?id={id}");
        }

        public async Task Add(ClientViewModel record)
        {
            await _httpClient.PostAsJsonAsync("api/Client", record);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Client?id={id}");
        }

        public async Task Update(ClientViewModel record)
        {
            await _httpClient.PutAsJsonAsync("api/Client", record);
        }

        public async Task Return()
        {
            _navigationManager.NavigateTo("client/list");
        }
    }
}
