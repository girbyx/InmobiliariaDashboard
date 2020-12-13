using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ProjectViewModel Record { get; set; } = new ProjectViewModel();
        public IEnumerable<ProjectTypeEnum> ProjectTypes => BaseEnumeration.GetAll<ProjectTypeEnum>();
        public IBrowserFile[] Files { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();

            // defaults
            Record.StartDate = DateTime.Today;
            Record.ProjectType = ProjectTypeEnum.FixedAsset.Code;
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            Files = e.GetMultipleFiles().ToArray();
        }

        protected async Task HandleValidSubmit()
        {
            var id = await Service.Add(Record);
            if(Files.Any())
                await Service.AddFiles(id, Files);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}