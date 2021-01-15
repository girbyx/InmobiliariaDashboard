using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Asset
{
    public interface IService : IBaseCatalogService<AssetViewModel>
    {

    }

    public class Service : BaseCatalogService<AssetViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Asset";
            DetailControllerName = "AssetDetail";
        }
    }
}