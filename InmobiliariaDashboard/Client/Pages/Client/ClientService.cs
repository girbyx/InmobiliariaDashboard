using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public interface IClientService : IBaseCatalogService<ClientViewModel>
    {

    }

    public class ClientService : BaseCatalogService<ClientViewModel>, IClientService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ClientService(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            ControllerName = "Client";
            DetailControllerName = "ClientDetail";
        }
    }
}