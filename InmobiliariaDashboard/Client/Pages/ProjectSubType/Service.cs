﻿using System.Net.Http;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.ProjectSubType
{
    public interface IService : IBaseCatalogService<ProjectSubTypeViewModel>
    {

    }

    public class Service : BaseCatalogService<ProjectSubTypeViewModel>, IService
    {
        public Service(HttpClient httpClient, NavigationManager navigationManager)
            : base(httpClient, navigationManager)
        {
            ControllerName = "ProjectSubType";
            DetailControllerName = "ProjectSubTypeDetail";
        }
    }
}