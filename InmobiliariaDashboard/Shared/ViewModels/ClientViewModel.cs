using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
    }
}