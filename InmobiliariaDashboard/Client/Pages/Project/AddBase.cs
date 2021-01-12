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
        public bool Saving { get; set; }
        public ProjectViewModel Record { get; set; } = new ProjectViewModel();
        public IEnumerable<ProjectTypeEnum> ProjectTypes => BaseEnumeration.GetAll<ProjectTypeEnum>();
        public IEnumerable<ProjectSubTypeViewModel> ProjectSubTypes { get; set; }
        public IBrowserFile[] Files { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();
            ProjectSubTypes = Record.ProjectSubTypes;

            // defaults
            Record.StartDate = DateTime.Today;
            Record.ProjectType = ProjectTypeEnum.FixedAsset.Code;
            ProjectSubTypes = Record.ProjectSubTypes.Where(x => x.ProjectType == Record.ProjectType);
            Record.ProjectSubTypeId = Record.ProjectSubTypes.FirstOrDefault(x => x.ProjectType == Record.ProjectType)?.Id ?? 0;
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            Files = e.GetMultipleFiles().ToArray();
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            var id = await Service.Add(Record);
            if(Files != null && Files.Any())
                await Service.AddFiles(id, Files);
            Saving = false;
            await Service.Return();
        }

        protected async Task OnProjectTypeChange(string code)
        {
            ProjectSubTypes = Record.ProjectSubTypes.Where(x => x.ProjectType == code);
            Record.ProjectSubTypeId = Record.ProjectSubTypes.FirstOrDefault(x => x.ProjectType == code)?.Id ?? 0;
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}