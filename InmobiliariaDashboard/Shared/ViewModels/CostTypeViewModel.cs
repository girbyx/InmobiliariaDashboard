using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class CostTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}