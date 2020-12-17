using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class SendBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        [Parameter] public string Id { get; set; }
        public bool Saving { get; set; }
        public IEnumerable<ContactViewModel> Contacts { get; set; }
        public SendProjectInformationViewModel Record { get; set; } = new SendProjectInformationViewModel();

        protected override async Task OnInitializedAsync()
        {
            var id = int.Parse(Id);
            Record.ProjectId = id;
            Contacts = (await Service.Get(id)).EnterpriseContacts;
        }

        protected async Task HandleValidSubmit()
        {
            Saving = true;
            await Service.EmailProjectInformation(Record);
            Saving = false;
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}