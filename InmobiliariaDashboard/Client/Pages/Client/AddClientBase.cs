using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public class AddClientBase : ComponentBase
    {
        [Inject] public IClientService ClientService { get; set; }
        public ClientViewModel Record { get; set; } = new ClientViewModel();

        protected async Task HandleValidSubmit()
        {
            await ClientService.Add(Record);
            await ClientService.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await ClientService.Return();
        }
    }
}