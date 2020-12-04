using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Client : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        // audit & relationships
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();
        }
    }
}