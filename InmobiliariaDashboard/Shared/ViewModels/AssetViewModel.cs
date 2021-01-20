using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class AssetViewModel : ISelectableViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Value { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        [Required] public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una entidad")]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione tipo de activo")]
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }

        // select lists
        public IEnumerable<PeopleViewModel> Peoples { get; set; }
        public IEnumerable<AssetTypeViewModel> AssetTypes { get; set; }
    }
}