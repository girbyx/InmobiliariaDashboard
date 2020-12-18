﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class GainViewModel : IIUploadFiles
    {
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un tipo de ingreso")]
        public int GainTypeId { get; set; }
        public string GainTypeName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un proyecto")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un agente monetario")]
        public int MonetaryAgentId { get; set; }
        public string MonetaryAgentName { get; set; }

        // select lists
        public IEnumerable<GainTypeViewModel> GainTypes { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<MonetaryAgentViewModel> MonetaryAgents { get; set; }

        // lists
        public IEnumerable<AttachmentViewModel> Attachments { get; set; }
    }
}