using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class BankAccount : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        public string MonetaryAgentType { get; set; }

        // audit & relationships
        public int EnterpriseId { get; set; }
        public virtual People People { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Loss> Losses { get; set; }
    }

    public class MonetaryAgentProfile : Profile
    {
        public MonetaryAgentProfile()
        {
            CreateMap<BankAccount, MonetaryAgentViewModel>()
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>());
            CreateMap<MonetaryAgentViewModel, BankAccount>();
            CreateMap<BankAccount, MonetaryAgentBalanceViewModel>()
                .ForMember(dest => dest.LossValue, opt => opt.MapFrom(src => src.Losses.Sum(x => x.Total)))
                .ForMember(dest => dest.CostValue, opt => opt.MapFrom(src => src.Costs.Sum(x => x.Total)))
                .ForMember(dest => dest.GainValue, opt => opt.MapFrom(src => src.Gains.Sum(x => x.SubTotal)));
        }
    }
}