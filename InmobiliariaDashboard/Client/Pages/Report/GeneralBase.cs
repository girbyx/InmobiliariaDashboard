using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ReportViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Report
{
    public class GeneralBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public GeneralBalancePeopleViewModel Record { get; set; } = new GeneralBalancePeopleViewModel();

        protected override async Task OnInitializedAsync()
        {
            Record.Peoples = await Service.GetPeopleList();
        }
    }
}