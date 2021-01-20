using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.AutomapperResolvers;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class Project : IIdentityFields, IAuditFields, ICanBeArchived, IHasHistory<Project, ProjectHistory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }
        public bool Sold { get; set; }
        public double PurchasePrice { get; set; }
        public double MinimumSellingPrice { get; set; }
        public double MaximumSellingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Prospect { get; set; }

        // audit & relationships
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
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
        public virtual ICollection<Attachment> Attachments { get; set; }
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
                .ForMember(dest => dest.Peoples, opt => opt.MapFrom<PeoplesResolver>())
                .ForMember(dest => dest.ProjectSubTypes, opt => opt.MapFrom<ProjectSubTypesResolver>());
            CreateMap<ProjectViewModel, Project>();
        }
    }
}