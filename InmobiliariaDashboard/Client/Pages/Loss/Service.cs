using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Loss
{
    public interface IService : IBaseCatalogService<LossViewModel>, IBaseDependentService
    {
    }

    public class Service : BaseDependentService<LossViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Loss";
            DetailControllerName = "LossDetail";
        }
    }
}