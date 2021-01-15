using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Reminder
{
    public interface IService : IBaseCatalogService<ReminderViewModel>
    {

    }

    public class Service : BaseCatalogService<ReminderViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Reminder";
            DetailControllerName = "ReminderDetail";
        }
    }
}