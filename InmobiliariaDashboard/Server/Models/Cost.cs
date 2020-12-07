using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.Enumerations;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Cost : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public double Commission { get; set; }
        public string CommissionType { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public double Total => CommissionTypeEnum.FlatCash.Code == CommissionType ? (Value + Commission) :
            CommissionTypeEnum.Percentage.Code == CommissionType ? (Value * (1 + (Commission / 100))) : Value;

        // audit & relationships
        public int CostTypeId { get; set; }
        public virtual CostType CostType { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Attachment> Attachments { get; set; }
    }

    public class CostProfile : Profile
    {
        public CostProfile()
        {
            CreateMap<Cost, CostViewModel>()
                .ForMember(dest => dest.CostTypes, opt => opt.MapFrom<CostTypesResolver>())
                .ForMember(dest => dest.Projects, opt => opt.MapFrom<ProjectsResolver>())
                .ForMember(dest => dest.Accounts, opt => opt.MapFrom<AccountsResolver>());
            CreateMap<CostViewModel, Cost>();
        }
    }
}