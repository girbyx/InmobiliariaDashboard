using System;
using System.Collections.Generic;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class ProjectSubType : IIdentityFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }

        // audit & relationships
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // collections
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class ProjectSubTypeProfile : Profile
    {
        public ProjectSubTypeProfile()
        {
            CreateMap<ProjectSubType, ProjectSubTypeViewModel>();
            CreateMap<ProjectSubTypeViewModel, ProjectSubType>();
        }
    }
}