using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class BankAccountViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        [Required] public string MonetaryAgentType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una persona")]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }

        // select lists
        public IEnumerable<PeopleViewModel> Peoples { get; set; }
    }
}