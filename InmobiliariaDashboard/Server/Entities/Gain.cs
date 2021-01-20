using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
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
        public int? PeopleId { get; set; }
        public virtual People People { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
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
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId ?? 0))
                .ForMember(dest => dest.GainTypes, opt => opt.MapFrom<GainTypesResolver>())
                .ForMember(dest => dest.Peoples, opt => opt.MapFrom<PeoplesResolver>())
                .ForMember(dest => dest.Projects, opt => opt.MapFrom<ProjectsResolver>());
            CreateMap<GainViewModel, Gain>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId == 0 ? null : (int?)src.ProjectId));
        }
    }
}