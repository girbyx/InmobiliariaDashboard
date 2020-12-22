using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Loss
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public bool Saving { get; set; }
        public LossViewModel Record { get; set; } = new LossViewModel();
        public IEnumerable<CommissionTypeEnum> CommissionTypes => BaseEnumeration.GetAll<CommissionTypeEnum>();
        public IBrowserFile[] Files { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();

            // defaults
            Record.CommissionType = CommissionTypeEnum.Money.Code;
            Record.MonetaryAgents = await Service.GetMonetaryAgentsByProject(Record.ProjectId);
            Record.Date = DateTime.Now;
        }

        protected async Task HandleFileSelection(InputFileChangeEventArgs e)
        {
            Files = e.GetMultipleFiles().ToArray();
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            var id = await Service.Add(Record);
            if (Files != null && Files.Any())
                await Service.AddFiles(id, Files);
            Saving = false;
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