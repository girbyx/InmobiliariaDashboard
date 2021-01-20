using System;
using AutoMapper;
using InmobiliariaDashboard.Server.Entities.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Entities
{
    public class ProjectHistory : IAuditFields, IIAmHistory<Project>
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

        // audit & relationships
        public int PeopleId { get; set; }
        public virtual People People { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        // history specific
        public int? OriginalId { get; set; }
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