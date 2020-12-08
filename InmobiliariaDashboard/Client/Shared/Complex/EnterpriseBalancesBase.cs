using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Shared.Complex
{
    public class EnterpriseBalancesBase : ComponentBase
    {
        [Inject] public IEnterpriseBalancesService Service { get; set; }
        public IEnumerable<BalanceViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetList();
        }
    }
}