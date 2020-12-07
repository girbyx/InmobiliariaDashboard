using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public interface IService : IBaseCatalogService<ProjectViewModel>
    {

    }

    public class Service : BaseCatalogService<ProjectViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Project";
            DetailControllerName = "ProjectDetail";
        }
    }
}