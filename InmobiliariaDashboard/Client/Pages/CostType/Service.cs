using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.CostType
{
    public interface IService : IBaseCatalogService<CostTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<CostTypeViewModel>, IService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            ControllerName = "CostType";
            DetailControllerName = "CostTypeDetail";
        }
    }
}