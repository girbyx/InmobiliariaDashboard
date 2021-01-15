using AutoMapper;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Server.Services;
using InmobiliariaDashboard.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InmobiliariaDashboard.Server.Controllers.Project
{
    [ApiController]
    [Route("api/[controller]")]
    public class
        ProjectDetailController : BaseDetailController<ProjectDetailController, Entities.Project, ProjectHistory,
            ProjectViewModel>
    {
        public ProjectDetailController(ILogger<ProjectDetailController> logger, IMapper mapper,
            IProjectService baseService) : base(logger, mapper, baseService)
        {
        }
    }
}