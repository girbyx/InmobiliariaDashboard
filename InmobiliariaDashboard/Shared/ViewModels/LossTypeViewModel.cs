using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class LossTypeViewModel : IISelectableViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}