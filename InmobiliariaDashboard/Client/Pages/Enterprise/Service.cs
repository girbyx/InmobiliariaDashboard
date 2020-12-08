using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Enterprise
{
    public interface IService : IBaseCatalogService<EnterpriseViewModel>
    {

    }

    public class Service : BaseCatalogService<EnterpriseViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Enterprise";
            DetailControllerName = "EnterpriseDetail";
        }
    }
}