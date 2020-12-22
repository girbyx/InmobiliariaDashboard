using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class HistoryBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public IEnumerable<ProjectViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Records = await Service.GetHistory(id);
        }
    }
}