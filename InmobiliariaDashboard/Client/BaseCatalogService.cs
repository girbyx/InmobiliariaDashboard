using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace InmobiliariaDashboard.Client
{
    public class BaseCatalogService<TViewModel> : IBaseCatalogService<TViewModel> where TViewModel : class
    {
        protected string ControllerName;
        protected string DetailControllerName;

        protected readonly HttpClient HttpClient;
        protected readonly NavigationManager NavigationManager;

        public BaseCatalogService(HttpClient httpClient, NavigationManager navigationManager)
        {
            HttpClient = httpClient;
            NavigationManager = navigationManager;
            ControllerName = "";
            DetailControllerName = "";
        }

        public async Task<IEnumerable<TViewModel>> GetList()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<TViewModel>>($"api/{ControllerName}");
        }

        public async Task<TViewModel> Get(int id)
        {
            return await HttpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}?id={id}");
        }

        public async Task<TViewModel> GetEmpty()
        {
            return await HttpClient.GetFromJsonAsync<TViewModel>($"api/{DetailControllerName}/GetEmpty");
        }

        public async Task<int> Add(TViewModel record)
        {
            var response = await HttpClient.PostAsJsonAsync($"api/{ControllerName}", record);
            var id = Convert.ToInt32(await response.Content.ReadAsStringAsync());
            return id;
        }

        //public async Task AddFiles(int id, IEnumerable<IFormFile> record)
        //{
        //    var form = new MultipartFormDataContent
        //    {
        //        {new StringContent(id.ToString()), "id"}
        //    };
        //    await HttpClient.PostAsync($"api/{ControllerName}", form);
        //}

        public async Task Delete(int id)
        {
            await HttpClient.DeleteAsync($"api/{ControllerName}?id={id}");
        }

        public async Task Archive(int id)
        {
            await HttpClient.DeleteAsync($"api/{ControllerName}/Archive?id={id}");
        }

        public async Task Update(TViewModel record)
        {
            await HttpClient.PutAsJsonAsync($"api/{ControllerName}", record);
        }

        public async Task Return()
        {
            NavigationManager.NavigateTo($"{ControllerName.ToLower()}/list");
        }
    }
}