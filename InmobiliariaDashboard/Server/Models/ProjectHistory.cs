using System;
using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class ProjectHistory : IIAmHistory<Project>
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

        // history specific
        public int OriginalId { get; set; }
        public virtual Project Original { get; set; }
    }

    public class ProjectHistoryProfile : Profile
    {
        public ProjectHistoryProfile()
        {
            CreateMap<Project, ProjectHistory>();

            CreateMap<ProjectHistory, ProjectViewModel>();
            CreateMap<ProjectViewModel, ProjectHistory>();
        }
    }
}