using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Gain
{
    public interface IService : IBaseCatalogService<GainViewModel>, IBaseDependentService
    {
    }

    public class Service : BaseDependentService<GainViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Gain";
            DetailControllerName = "GainDetail";
        }
    }
}