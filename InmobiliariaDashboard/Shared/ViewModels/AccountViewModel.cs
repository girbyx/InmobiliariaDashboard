﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        // select lists
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}