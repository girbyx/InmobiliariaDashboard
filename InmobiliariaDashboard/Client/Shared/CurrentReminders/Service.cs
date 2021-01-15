using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Shared.CurrentReminders
{
    public interface IService : IBaseCatalogService<ReminderViewModel>, IBaseDependentService
    {
        Task<IEnumerable<ReminderViewModel>> GetCurrent();
    }

    public class Service : BaseDependentService<ReminderViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "Reminder";
            DetailControllerName = "ReminderDetail";
        }

        public async Task<IEnumerable<ReminderViewModel>> GetCurrent()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<ReminderViewModel>>($"api/{ControllerName}/GetCurrent");
        }
    }
}