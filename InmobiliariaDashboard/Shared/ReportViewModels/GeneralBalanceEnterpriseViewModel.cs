using System.Collections.Generic;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Shared.ReportViewModels
{
    public class GeneralBalanceEnterpriseViewModel
    {
        public int Id { get; set; }
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
    }
}
