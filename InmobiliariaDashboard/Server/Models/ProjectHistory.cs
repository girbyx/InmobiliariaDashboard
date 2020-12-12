using AutoMapper;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Server.Models
{
    public class ProjectHistory : Project, IIAmHistory<Project>
    {
        public int OriginalId { get; set; }
        public virtual Project Original { get; set; }
    }

    public class ProjectHistoryProfile : Profile
    {
        public ProjectHistoryProfile()
        {
            CreateMap<ProjectHistory, ProjectViewModel>();
            CreateMap<ProjectViewModel, ProjectHistory>();
        }
    }
}