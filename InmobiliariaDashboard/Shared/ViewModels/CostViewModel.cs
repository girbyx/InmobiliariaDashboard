using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class CostViewModel : IFileUploader
    {
        public int Id { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
        public double SubTotal { get; set; }
        public double Commission { get; set; }
        [Required]
        public string CommissionType { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un tipo de gasto")]
        public int CostTypeId { get; set; }
        public string CostTypeName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una entidad")]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una cuenta")]
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }

        // select lists
        public IEnumerable<CostTypeViewModel> CostTypes { get; set; }
        public IEnumerable<PeopleViewModel> Peoples { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<BankAccountViewModel> MonetaryAgents { get; set; }

        // lists
        public IEnumerable<AttachmentViewModel> Attachments { get; set; }
    }
}