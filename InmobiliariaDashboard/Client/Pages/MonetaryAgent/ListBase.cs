using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.MonetaryAgent
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<BankAccountViewModel> OriginalRecords;
        public IEnumerable<BankAccountViewModel> Records;

        protected async Task FilterRecords(ChangeEventArgs e)
        {
            var searchValue = e.Value.ToString().ToLower();
            Records = OriginalRecords.Where(x =>
                x.PeopleName.ToLower().Contains(searchValue)
                || x.Name.ToLower().Contains(searchValue)
                || (x.AccountNumber?.ToString().ToLower().Contains(searchValue) ?? false)
                || (x.CardNumber?.ToString().ToLower().Contains(searchValue) ?? false)
                || BaseEnumeration.FromCode<BankAccountTypeEnum>(x.MonetaryAgentType).DisplayName.ToLower().Contains(searchValue));
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