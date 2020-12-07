using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Cost
{
    public class EditBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public CostViewModel Record { get; set; } = new CostViewModel();
        public IEnumerable<CommissionTypeEnum> CommissionTypes => BaseEnumeration.GetAll<CommissionTypeEnum>();

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record = await Service.Get(id);

            // defaults
            Record.Accounts = await Service.GetAccountsByProject(Record.ProjectId);
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Update(Record);
            await Service.Return();
        }

        protected async Task OnProjectChange(int id)
        {
            Record.Accounts = await Service.GetAccountsByProject(id);
        }

        protected async Task OnDeleteClick(MouseEventArgs e)
        {
            var id = int.Parse(Id);
            await Service.Delete(id);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}