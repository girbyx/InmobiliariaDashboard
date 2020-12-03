using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Client
{
    public class ListClientBase : ComponentBase
    {
        [Inject] public IClientService ClientService { get; set; }
        public IEnumerable<ClientViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await ClientService.GetList();
        }
    }
}