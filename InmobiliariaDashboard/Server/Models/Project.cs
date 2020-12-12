using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Project : IIdentityFields, IAuditFields, IHaveHistory<Project, ProjectHistory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // audit & relationships
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Loss> Losses { get; set; }

        // history
        public virtual ICollection<ProjectHistory> History { get; set; }
    }

    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>());
            CreateMap<ProjectViewModel, Project>();
        }
    }
}