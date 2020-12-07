using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class CostViewModel
    {
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        public double Commission { get; set; }
        public string CommissionType { get; set; }
        [Required]
        public string Description { get; set; }
        public int Total { get; set; }
        public DateTime Created { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please, select a cost type")]
        public int CostTypeId { get; set; }
        public string CostTypeName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please, select a project")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please, select an account")]
        public int AccountId { get; set; }
        public string AccountName { get; set; }

        // select lists
        public IEnumerable<CostTypeViewModel> CostTypes { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<AccountViewModel> Accounts { get; set; }
    }
}