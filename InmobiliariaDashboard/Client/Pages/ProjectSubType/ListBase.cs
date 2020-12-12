using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.ProjectSubType
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ProjectSubTypeViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetList();
        }
    }
}