using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public interface IService : IBaseCatalogService<ClientViewModel>
    {

    }

    public class Service : BaseCatalogService<ClientViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Client";
            DetailControllerName = "ClientDetail";
        }
    }
}