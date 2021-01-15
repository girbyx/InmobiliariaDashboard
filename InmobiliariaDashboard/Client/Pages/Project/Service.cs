using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public interface IService : IBaseCatalogService<ProjectViewModel>, IBaseDependentService
    {
    }

    public class Service : BaseDependentService<ProjectViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Project";
            DetailControllerName = "ProjectDetail";
        }
    }
}