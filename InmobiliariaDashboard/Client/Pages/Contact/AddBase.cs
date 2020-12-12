using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace InmobiliariaDashboard.Client.Pages.Contact
{
    public class AddBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public ContactViewModel Record { get; set; } = new ContactViewModel();

        protected override async Task OnInitializedAsync()
        {
            Record = await Service.GetEmpty();
        }

        protected async Task HandleValidSubmit()
        {
            await Service.Add(Record);
            await Service.Return();
        }

        protected async Task OnCancelClick(MouseEventArgs e)
        {
            await Service.Return();
        }
    }
}