using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Asset
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<AssetViewModel> OriginalRecords;
        public IEnumerable<AssetViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.EnterpriseName.ToLower().Contains(searchValue)
                || x.Name.ToLower().Contains(searchValue)
                || x.Value.ToString("C").ToLower().Contains(searchValue)
                || x.Quantity.ToString("N").ToLower().Contains(searchValue)
                || x.SubTotal.ToString("C").ToLower().Contains(searchValue)
                || x.AssetTypeName.ToLower().Contains(searchValue));
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