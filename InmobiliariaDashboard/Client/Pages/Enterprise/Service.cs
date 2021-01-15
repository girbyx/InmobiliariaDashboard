using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Enterprise
{
    public interface IService : IBaseCatalogService<PeopleViewModel>
    {

    }

    public class Service : BaseCatalogService<PeopleViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Enterprise";
            DetailControllerName = "EnterpriseDetail";
        }
    }
}