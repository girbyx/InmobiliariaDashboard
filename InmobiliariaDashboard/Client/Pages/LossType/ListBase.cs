using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.LossType
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<LossTypeViewModel> OriginalRecords;
        public IEnumerable<LossTypeViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.Name.ToLower().Contains(searchValue)
                || x.Description.ToLower().Contains(searchValue));
        }

        protected override async Task OnInitializedAsync()
        {
            Records = OriginalRecords = await Service.GetList();
        }

        protected async Task OnDeleteClick(int id)
        {
            await Service.Delete(id);
            OriginalRecords = OriginalRecords.Where(x => x.Id != id);
            Records = Records.Where(x => x.Id != id);
        }
    }
}