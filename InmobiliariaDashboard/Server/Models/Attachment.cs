using System;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Attachment : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ExtensionType { get; set; }

        // audit & relationships
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? GainId { get; set; }
        public virtual Gain Gain { get; set; }
        public int? CostId { get; set; }
        public virtual Cost Cost { get; set; }
        public int? LossId { get; set; }
        public virtual Loss Loss { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentViewModel>();
            CreateMap<AttachmentViewModel, Attachment>();
        }
    }
}