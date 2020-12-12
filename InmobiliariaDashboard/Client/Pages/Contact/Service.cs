using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Contact
{
    public interface IService : IBaseCatalogService<ContactViewModel>
    {

    }

    public class Service : BaseCatalogService<ContactViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Contact";
            DetailControllerName = "ContactDetail";
        }
    }
}