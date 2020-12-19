using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class ProjectViewModel : ISelectableViewModel, IIUploadFiles
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }
        public string Description { get; set; }
        [Required] public string ProjectType { get; set; }
        public bool Sold { get; set; }
        public double PurchasePrice { get; set; }
        public double MinimumSellingPrice { get; set; }
        public double MaximumSellingPrice { get; set; }
        [Required] public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una empresa")]
        public int EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione un sub-tipo")]
        public int ProjectSubTypeId { get; set; }
        public string ProjectSubTypeName { get; set; }

        // select lists
        public IEnumerable<EnterpriseViewModel> Enterprises { get; set; }
        public IEnumerable<ProjectSubTypeViewModel> ProjectSubTypes { get; set; }

        // lists
        public IEnumerable<ContactViewModel> EnterpriseContacts { get; set; }
        public IEnumerable<AttachmentViewModel> Attachments { get; set; }
    }
}