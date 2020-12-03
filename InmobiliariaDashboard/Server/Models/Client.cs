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
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        // audit & relationships
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Account> Account { get; set; }
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