using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Gain : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        [NotMapped] public double SubTotal => Value * Quantity;
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // audit & relationships
        public int GainTypeId { get; set; }
        public virtual GainType GainType { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int MonetaryAgentId { get; set; }
        public virtual MonetaryAgent MonetaryAgent { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Attachment> Attachments { get; set; }
    }

    public class GainProfile : Profile
    {
        public GainProfile()
        {
            CreateMap<Gain, GainViewModel>()
                .ForMember(dest => dest.GainTypes, opt => opt.MapFrom<GainTypesResolver>())
                .ForMember(dest => dest.Projects, opt => opt.MapFrom<ProjectsResolver>());
            CreateMap<GainViewModel, Gain>();
        }
    }
}