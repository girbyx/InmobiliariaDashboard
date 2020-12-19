using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.LossType
{
    public interface IService : IBaseCatalogService<LossTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<LossTypeViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "LossType";
            DetailControllerName = "LossTypeDetail";
        }
    }
}