using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public string CurrentUserName { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var result = await Service.GetCurrentUserName();
            CurrentUserName = string.IsNullOrEmpty(result) ? "Invitado" : result;
        }
    }
}