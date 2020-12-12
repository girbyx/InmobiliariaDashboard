using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Server.Resolvers;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class Project : IIdentityFields, IAuditFields, ICanBeArchived, IHaveHistory<Project, ProjectHistory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }
        public bool Sold { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // audit & relationships
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public int ProjectSubTypeId { get; set; }
        public virtual ProjectSubType ProjectSubType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool Archived { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public string ArchivedBy { get; set; }

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
                .ForMember(dest => dest.Enterprises, opt => opt.MapFrom<EnterprisesResolver>())
                .ForMember(dest => dest.ProjectSubTypes, opt => opt.MapFrom<ProjectSubTypesResolver>());
            CreateMap<ProjectViewModel, Project>();
        }
    }
}