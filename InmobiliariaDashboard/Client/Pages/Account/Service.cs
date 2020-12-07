using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Account
{
    public interface IService : IBaseCatalogService<AccountViewModel>
    {

    }

    public class Service : BaseCatalogService<AccountViewModel>, IService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            ControllerName = "Account";
            DetailControllerName = "AccountDetail";
        }
    }
}