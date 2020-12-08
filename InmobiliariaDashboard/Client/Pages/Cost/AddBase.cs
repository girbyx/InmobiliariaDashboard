using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Cost
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public CostViewModel Record { get; set; } = new CostViewModel();
        public IEnumerable<CommissionTypeEnum> CommissionTypes => BaseEnumeration.GetAll<CommissionTypeEnum>();

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();

            // defaults
            Record.CommissionType = CommissionTypeEnum.Money.Code;
            Record.MonetaryAgents = await Service.GetMonetaryAgentsByProject(Record.ProjectId);
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Add(Record);
            await Service.Return();
        }

        protected async Task OnProjectChange(int id)
        {
            Record.MonetaryAgents = await Service.GetMonetaryAgentsByProject(id);
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}