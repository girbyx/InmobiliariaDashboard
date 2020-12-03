using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Client name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Telephone 1")]
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        [Required]
        [DisplayName("Address 1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
}