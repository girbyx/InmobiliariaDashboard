using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Cost
{
    public interface IService : IBaseCatalogService<CostViewModel>, IBaseDependentService
    {
    }

    public class Service : BaseDependentService<CostViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Cost";
            DetailControllerName = "CostDetail";
        }
    }
}