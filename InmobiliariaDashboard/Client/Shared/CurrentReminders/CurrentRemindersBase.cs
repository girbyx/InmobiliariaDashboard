using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Shared.CurrentReminders
{
    public class CurrentRemindersBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ReminderViewModel> Records;

        protected override async Task OnInitializedAsync()
        {
            Records = await Service.GetCurrent();
        }
    }
}