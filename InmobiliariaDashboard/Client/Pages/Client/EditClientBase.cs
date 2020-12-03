using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public class EditClientBase : ComponentBase
    {
        [Inject] public IClientService ClientService { get; set; }
        [Parameter] public string Id { get; set; }
        public ClientViewModel Record { get; set; } = new ClientViewModel();

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record = await ClientService.Get(id);
        }

        protected async Task HandleValidSubmit()
        {
            await ClientService.Update(Record);
            await ClientService.Return();
        }

        protected async Task OnDeleteClick(MouseEventArgs e)
        {
            var id = int.Parse(Id);
            await ClientService.Delete(id);
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await ClientService.Return();
        }
    }
}