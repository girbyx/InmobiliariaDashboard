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
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Account";
            DetailControllerName = "AccountDetail";
        }
    }
}