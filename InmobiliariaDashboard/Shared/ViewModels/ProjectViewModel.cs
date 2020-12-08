using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ProjectViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }

        [Required] public string ProjectType { get; set; }
        [Required] public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una empresa")]
        public int EnterpriseId { get; set; }

        public string EnterpriseName { get; set; }

        // select lists
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
    }
}