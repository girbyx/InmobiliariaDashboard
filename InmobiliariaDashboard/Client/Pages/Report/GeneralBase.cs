using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ReportViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Report
{
    public class GeneralBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public GeneralBalanceEnterpriseViewModel Record { get; set; } = new GeneralBalanceEnterpriseViewModel();

        protected override async Task OnInitializedAsync()
        {
            Record.Enterprises = await Service.GetEnterpriseList();
        }
    }
}