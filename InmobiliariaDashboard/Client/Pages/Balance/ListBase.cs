using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InmobiliariaDashboard.Client.Pages.Balance
{
    public class ListBase : ComponentBase
    {
        [Inject] public IService Service { get; set; }
        public IEnumerable<PeopleBalanceViewModel> EnterpriseRecords;
        public IEnumerable<BankAccountBalanceViewModel> MonetaryAgentRecords;

        protected override async Task OnInitializedAsync()
        {
            EnterpriseRecords = await Service.GetEnterpriseList();
            MonetaryAgentRecords = await Service.GetMonetaryAgentList();
        }
    }
}