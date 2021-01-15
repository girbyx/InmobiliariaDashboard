using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class Cost : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
        [NotMapped] public double SubTotal => Value * Quantity;
        public double Commission { get; set; }
        public string CommissionType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public double Total => CommissionTypeEnum.Money.Code == CommissionType ? (SubTotal + Commission) :
            CommissionTypeEnum.Percentage.Code == CommissionType ? (SubTotal * (1 + (Commission / 100))) : SubTotal;

        // audit & relationships
        public int CostTypeId { get; set; }
        public virtual CostType CostType { get; set; }
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public int? ProjectId { get; set; }
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

    public class CostProfile : Profile
    {
        public CostProfile()
        {
            CreateMap<Cost, CostViewModel>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId ?? 0))
                .ForMember(dest => dest.CostTypes, opt => opt.MapFrom<CostTypesResolver>())
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>())
                .ForMember(dest => dest.Projects, opt => opt.MapFrom<ProjectsResolver>());
            CreateMap<CostViewModel, Cost>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId == 0 ? null : (int?)src.ProjectId));
        }
    }
}