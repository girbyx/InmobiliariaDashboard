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
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "CostType";
            DetailControllerName = "CostTypeDetail";
        }
    }
}