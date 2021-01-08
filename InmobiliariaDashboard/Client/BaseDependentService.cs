using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client
{
    public class BaseDependentService<TViewModel> : BaseCatalogService<TViewModel>, IBaseDependentService
        where TViewModel : class
    {
        public BaseDependentService(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
        }

        public async Task<bool> EmailProjectInformation(SendProjectInformationViewModel record)
        {
            var response = await HttpClient.PostAsJsonAsync("api/Project/SendProjectInformation", record);
            var success = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            return success;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsByEnterprise(int id)
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<ProjectViewModel>>($"api/Project/ByEnterprise?id={id}");
        }

        public async Task<IEnumerable<MonetaryAgentViewModel>> GetMonetaryAgentsByEnterprise(int id)
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<MonetaryAgentViewModel>>($"api/MonetaryAgent/ByEnterprise?id={id}");
        }

        public async Task<IEnumerable<MonetaryAgentViewModel>> GetMonetaryAgentsByProject(int id)
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<MonetaryAgentViewModel>>($"api/MonetaryAgent/ByProject?id={id}");
        }
    }
}