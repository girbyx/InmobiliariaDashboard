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
    public class EditBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public bool Saving { get; set; }
        public ProjectViewModel Record { get; set; } = new ProjectViewModel();
        public IEnumerable<ProjectTypeEnum> ProjectTypes => BaseEnumeration.GetAll<ProjectTypeEnum>();
        public IBrowserFile[] Files { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record = await Service.Get(id);
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            Files = e.GetMultipleFiles().ToArray();
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            var id = await Service.Update(Record);
            if (Files.Any())
                await Service.AddFiles(id, Files);
            Saving = false;
            await Service.Return();
        }

        protected async Task OnDeleteAttachmentClick(int id)
        {
            Saving = true;
            //await Service.DeleteAttachment(id);
            Record.Attachments = Record.Attachments.Where(x => x.Id != id);
            Saving = false;
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