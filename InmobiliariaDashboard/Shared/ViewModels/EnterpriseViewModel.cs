using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class EnterpriseViewModel : IISelectableViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Description { get; set; }
    }
}