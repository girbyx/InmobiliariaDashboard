﻿using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.ProjectSubType
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ProjectSubTypeViewModel Record { get; set; } = new ProjectSubTypeViewModel();

        protected async Task HandleValidSubmit()
        {
            await Service.Add(Record);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}