using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Gain
{
    public class EditBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public bool Saving { get; set; }
        public GainViewModel Record { get; set; } = new GainViewModel();
        public IBrowserFile[] Files { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record = await Service.Get(id);

            // defaults
            Record.MonetaryAgents = await Service.GetMonetaryAgentsByProject(Record.ProjectId);
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            var id = await Service.Update(Record);
            if (Files != null && Files.Any())
                await Service.AddFiles(id, Files);
            Saving = false;
            await Service.Return();
        }

        protected async Task OnDeleteAttachmentClick(int id)
        {
            Saving = true;
            await Service.DeleteAttachment(id);
            Record.Attachments = Record.Attachments.Where(x => x.Id != id);
            Saving = false;
        }

        protected async Task OnProjectChange(int id)
        {
            Record.MonetaryAgents = await Service.GetMonetaryAgentsByProject(id);
        }

        protected async Task OnDeleteClick(MouseEventArgs e)
        {
            var id = int.Parse(Id);
            await Service.Delete(id);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}