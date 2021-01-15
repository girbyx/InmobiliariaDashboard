﻿using System.Net.Http;
using InmobiliariaDashboard.Client.Shared.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.MonetaryAgent
{
    public interface IService : IBaseCatalogService<BankAccountViewModel>
    {

    }

    public class Service : BaseCatalogService<BankAccountViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "MonetaryAgent";
            DetailControllerName = "MonetaryAgentDetail";
        }
    }
}