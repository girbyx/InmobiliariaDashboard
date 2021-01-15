using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.AssetType
{
    public interface IService : IBaseCatalogService<AssetTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<AssetTypeViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "AssetType";
            DetailControllerName = "AssetTypeDetail";
        }
    }
}