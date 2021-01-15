using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.GainType
{
    public interface IService : IBaseCatalogService<GainTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<GainTypeViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "GainType";
            DetailControllerName = "GainTypeDetail";
        }
    }
}