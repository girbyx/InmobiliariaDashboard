using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Enumerations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class AccountViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        [Required] public string AccountType { get; set; } = AccountTypeEnum.FlatCash.Code;

        [Range(1, int.MaxValue, ErrorMessage = "Please, select a client")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        // select lists
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}