using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using InmobiliariaDashboard.Server.Extensions;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Reminder : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RecurrentOn { get; set; }
        public string ReminderFrequency { get; set; }
        [NotMapped] public DateTime NextOccurrence => RecurrentOn.NextOccurrence(ReminderFrequency);
        [NotMapped] public double DaysForNextOccurrence => (NextOccurrence - DateTime.Now).TotalDays;
        [NotMapped] public double HoursForNextOccurrence => (NextOccurrence - DateTime.Now).TotalHours;
        public string Description { get; set; }

        // audit & relationships
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class ReminderProfile : Profile
    {
        public ReminderProfile()
        {
            CreateMap<Reminder, ReminderViewModel>()
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>());
            CreateMap<ReminderViewModel, Reminder>();
        }
    }
}