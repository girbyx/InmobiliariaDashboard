using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class People : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }
        public string Description { get; set; }

        // audit & relationships
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Loss> Losses { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<BankAccount> MonetaryAgents { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }

    public class EnterpriseProfile : Profile
    {
        public EnterpriseProfile()
        {
            CreateMap<People, EnterpriseViewModel>();
            CreateMap<EnterpriseViewModel, People>();
            CreateMap<People, EnterpriseBalanceViewModel>()
                .ForMember(dest => dest.AssetValue, opt => opt.MapFrom(src => src.Assets.Sum(y => y.SubTotal)))
                .ForMember(dest => dest.ProjectPurchasePrice, opt => opt.MapFrom(src => src.Projects.Sum(y => y.PurchasePrice)))
                .ForMember(dest => dest.LossValue, opt => opt.MapFrom(src =>
                    src.Losses.Sum(z => z.Total) + src.Projects.Sum(y => y.Losses.Sum(z => z.Total))))
                .ForMember(dest => dest.CostValue, opt => opt.MapFrom(src =>
                    src.Costs.Sum(z => z.Total) + src.Projects.Sum(y => y.Costs.Sum(z => z.Total))))
                .ForMember(dest => dest.GainValue, opt => opt.MapFrom(src =>
                    src.Gains.Sum(z => z.SubTotal) + src.Projects.Sum(y => y.Gains.Sum(z => z.SubTotal))));
        }
    }
}