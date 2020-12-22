using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Cost
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<CostViewModel> OriginalRecords;
        public IEnumerable<CostViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.ProjectName.ToLower().Contains(searchValue)
                || x.CostTypeName.ToLower().Contains(searchValue)
                || x.MonetaryAgentName.ToLower().Contains(searchValue));
        }

        protected override async Task OnInitializedAsync()
        {
            Records = OriginalRecords = await Service.GetList();
        }
    }
}