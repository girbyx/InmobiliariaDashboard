using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class EditBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public bool Saving { get; set; }
        public ProjectViewModel Record { get; set; } = new ProjectViewModel();
        public IEnumerable<ProjectTypeEnum> ProjectTypes => BaseEnumeration.GetAll<ProjectTypeEnum>();

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record = await Service.Get(id);
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            await Service.Update(Record);
            Saving = false;
            await Service.Return();
        }

        protected async Task OnDeleteClick(MouseEventArgs e)
        {
            var id = int.Parse(Id);
            await Service.Delete(id);
            await Service.Return();
        }

        protected async Task OnArchiveClick(MouseEventArgs e)
        {
            var id = int.Parse(Id);
            await Service.Archive(id);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}