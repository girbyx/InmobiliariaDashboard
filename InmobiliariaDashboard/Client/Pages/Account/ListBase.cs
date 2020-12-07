using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Account
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<AccountViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetList();
        }
    }
}