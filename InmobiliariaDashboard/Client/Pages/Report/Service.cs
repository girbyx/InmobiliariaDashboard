using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Client.Pages.Report
{
    public interface IService
    {
        Task<IEnumerable<PeopleViewModel>> GetPeopleList();
    }

    public class Service : IService
    {
        private readonly HttpClient _httpClient;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PeopleViewModel>> GetPeopleList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PeopleViewModel>>("api/Enterprise");
        }
    }
}