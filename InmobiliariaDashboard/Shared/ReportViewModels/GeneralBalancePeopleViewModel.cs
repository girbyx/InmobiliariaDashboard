using System.Collections.Generic;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Shared.ReportViewModels
{
    public class GeneralBalancePeopleViewModel
    {
        public int Id { get; set; }
        public IEnumerable<PeopleViewModel> Enterprises { get; set; }
    }
}
