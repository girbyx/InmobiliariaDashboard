using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Enumerations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class MonetaryAgentViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        [Required] public string MonetaryAgentType { get; set; } = MonetaryAgentTypeEnum.Money.Code;

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una empresa")]
        public int EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }

        // select lists
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
    }
}