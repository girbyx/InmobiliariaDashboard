using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Client.Pages.Report
{
    public interface IService
    {
        Task<IEnumerable<EnterpriseViewModel>> GetEnterpriseList();
    }

    public class Service : IService
    {
        private readonly HttpClient _httpClient;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EnterpriseViewModel>> GetEnterpriseList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EnterpriseViewModel>>("api/Enterprise");
        }
    }
}