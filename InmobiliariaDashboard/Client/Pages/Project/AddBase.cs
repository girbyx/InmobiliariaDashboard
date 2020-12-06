using System;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ProjectViewModel Record { get; set; } = new ProjectViewModel();

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();

            // defaults
            Record.StartDate = DateTime.Today;
        }

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