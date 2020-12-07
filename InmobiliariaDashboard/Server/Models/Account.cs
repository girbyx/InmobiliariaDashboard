using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Account : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? AccountNumber { get; set; }
        public long? CardNumber { get; set; }
        public string AccountType { get; set; }

        // audit & relationships
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Loss> Losses { get; set; }
    }

    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.Clients, opt => opt.MapFrom<ClientsResolver>());
            CreateMap<AccountViewModel, Account>();
        }
    }
}