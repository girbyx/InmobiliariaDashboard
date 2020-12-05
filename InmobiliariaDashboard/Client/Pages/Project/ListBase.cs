using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ProjectViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetList();
        }
    }
}