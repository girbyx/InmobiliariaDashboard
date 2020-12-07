using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class CostViewModel
    {
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        public double? Commission { get; set; }
        public string CommissionType { get; set; }
        [Required]
        public string Description { get; set; }

        // select lists
        public IEnumerable<CostTypeViewModel> CostTypes { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<AccountViewModel> Accounts { get; set; }
    }
}