﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class AssetViewModel : IISelectableViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Value { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        [Required] public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una empresa")]
        public int EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una empresa")]
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }

        // select lists
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
        public IEnumerable<AssetTypeViewModel> AssetTypes { get; set; }
    }
}