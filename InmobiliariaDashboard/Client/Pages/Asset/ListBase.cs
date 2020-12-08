using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Asset
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<AssetViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetList();
        }
    }
}