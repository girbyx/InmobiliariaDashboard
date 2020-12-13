using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class CostViewModel : IIUploadFiles
    {
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public double Commission { get; set; }
        [Required]
        public string CommissionType { get; set; }
        [Required]
        public string Description { get; set; }
        public int Total { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un tipo de costo")]
        public int CostTypeId { get; set; }
        public string CostTypeName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un proyecto")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un agente monetario")]
        public int MonetaryAgentId { get; set; }
        public string MonetaryAgentName { get; set; }

        // select lists
        public IEnumerable<CostTypeViewModel> CostTypes { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<MonetaryAgentViewModel> MonetaryAgents { get; set; }

        // lists
        public IEnumerable<AttachmentViewModel> Attachments { get; set; }
    }
}