using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ContactViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        public string SuffixName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool Prospect { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una persona")]
        public int EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }

        // select lists
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
    }
}