using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class Contact : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string SuffixName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Prospect { get; set; }
        [NotMapped] public string Name => string.Join(" ", SuffixName, FirstName, MiddleName, LastName);
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string AddressExt { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }

        // audit & relationships
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>()
                .ForMember(dest => dest.Peoples, opt => opt.MapFrom<PeoplesResolver>());
            CreateMap<ContactViewModel, Contact>();
        }
    }
}