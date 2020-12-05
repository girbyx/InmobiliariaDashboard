﻿using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.GainType
{
    public interface IService : IBaseCatalogService<GainTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<GainTypeViewModel>, IService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            ControllerName = "GainType";
            DetailControllerName = "GainTypeDetail";
        }
    }
}