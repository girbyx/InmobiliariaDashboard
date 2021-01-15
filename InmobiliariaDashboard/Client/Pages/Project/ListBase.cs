using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Project
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<ProjectViewModel> OriginalRecords;
        public IEnumerable<ProjectViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.PeopleName.ToLower().Contains(searchValue)
                || x.Code.ToLower().Contains(searchValue)
                || x.Name.ToLower().Contains(searchValue)
                || BaseEnumeration.FromCode<ProjectTypeEnum>(x.ProjectType).DisplayName.ToLower().Contains(searchValue)
                || x.PurchasePrice.ToString("N").ToLower().Contains(searchValue)
                || x.MinimumSellingPrice.ToString("N").ToLower().Contains(searchValue)
                || x.MaximumSellingPrice.ToString("N").ToLower().Contains(searchValue)
                || x.StartDate.ToString("D").ToLower().Contains(searchValue));
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